using System.Security.Claims;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPGMakerAPI.Data;
using RPGMakerAPI.Interfaces;

namespace RPGMakerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        protected readonly RPGMakerContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseController(RPGMakerContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        // GET: api/[controller]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        // GET: api/[controller]/{id}
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return NotFound();

            return entity;
        }

        // POST: api/[controller]
        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            if (entity is IHasCreatedAt createdAtEntity)
                createdAtEntity.CreatedAt = DateTime.UtcNow;

            _dbSet.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = GetEntityId(entity) }, entity);
        }

        // PUT: api/[controller]/{id}
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, TEntity entity)
        {
            if (!UserOwnsEntity(entity))
                return Forbid();

            var entityId = GetEntityId(entity);
            if (entityId == null || !entityId.Equals(id))
                return BadRequest();

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _dbSet.FindAsync(id) == null)
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // PATCH: api/[controller]/{id}
        [HttpPatch("{id}")]
        public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<TEntity> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            // Validate only 'replace' operations are allowed
            foreach (var op in patchDoc.Operations)
            {
                if (!string.Equals(op.op, "replace", StringComparison.OrdinalIgnoreCase))
                    return BadRequest($"Only 'replace' operations are allowed. Invalid op: {op.op}");
            }

            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return NotFound();

            if (!UserOwnsEntity(entity))
                return Forbid();

            patchDoc.ApplyTo(entity, ModelState);

            if (!TryValidateModel(entity))
                return BadRequest(ModelState);

            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }

        // DELETE: api/[controller]/{id}
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return NotFound();

            if (!UserOwnsEntity(entity))
                return Forbid();

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private static object? GetEntityId(TEntity entity)
        {
            var prop = typeof(TEntity).GetProperty("Id");
            return prop?.GetValue(entity);
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                throw new UnauthorizedAccessException("User ID claim missing or invalid.");
            }
            return userId;
        }

        protected bool UserOwnsEntity(object? entity)
        {
            while (entity is IBelongsToUserChild child)
            {
                entity = child.GetParent();
                if (entity == null)
                    return false;
            }

            if (entity is IBelongsToUser owned)
            {
                return owned.CreatedByUserId == GetCurrentUserId();
            }

            return false;
        }


    }
}
