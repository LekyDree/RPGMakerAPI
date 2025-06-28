using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeInstanceController : BaseController<AttributeInstance>
    {
        public AttributeInstanceController(RPGMakerContext context) : base(context)
        {
        }
    }
}
