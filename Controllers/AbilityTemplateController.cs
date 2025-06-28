using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilityTemplateController : BaseController<AbilityTemplate>
    {
        public AbilityTemplateController(RPGMakerContext context) : base(context)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public override async Task<ActionResult<IEnumerable<AbilityTemplate>>> GetAll()
        {
            return await base.GetAll();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public override async Task<ActionResult<AbilityTemplate>> Get(int id)
        {
            return await base.Get(id);
        }

        [Authorize]
        [HttpPost]
        public override async Task<ActionResult<AbilityTemplate>> Post(AbilityTemplate entity)
        {
            return await base.Post(entity);
        }

        [Authorize]
        [HttpPut("{id}")]
        public override async Task<IActionResult> Put(int id, AbilityTemplate entity)
        {
            return await base.Put(id, entity);
        }

        [Authorize]
        [HttpPatch("{id}")]
        public override async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<AbilityTemplate> patchDoc)
        {
            return await base.Patch(id, patchDoc);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
