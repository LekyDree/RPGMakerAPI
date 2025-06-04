using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbilityTemplateController : ControllerBase
    {
        private readonly RPGMakerContext _context;

        public AbilityTemplateController(RPGMakerContext context)
        {
            _context = context;
        }

        // GET: api/abilitytemplate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbilityTemplate>>> GetAbilityTemplates()
        {
            return await _context.AbilityTemplates.ToListAsync();
        }

        // GET: api/abilitytemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AbilityTemplate>> GetAbilityTemplate(int id)
        {
            var abilityTemplate = await _context.AbilityTemplates.FindAsync(id);

            if (abilityTemplate == null)
            {
                return NotFound();
            }

            return abilityTemplate;
        }

        // POST: api/abilitytemplate
        [HttpPost]
        public async Task<ActionResult<AbilityTemplate>> CreateAbilityTemplate(AbilityTemplate template)
        {
            _context.AbilityTemplates.Add(template);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAbilityTemplate), new { id = template.Id }, template);
        }

        // PUT: api/abilitytemplate/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbilityTemplate(int id, AbilityTemplate template)
        {
            if (id != template.Id)
            {
                return BadRequest();
            }

            _context.Entry(template).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.AbilityTemplates.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/abilitytemplate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbilityTemplate(int id)
        {
            var template = await _context.AbilityTemplates.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }

            _context.AbilityTemplates.Remove(template);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
