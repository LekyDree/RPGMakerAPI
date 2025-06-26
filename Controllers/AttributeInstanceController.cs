using Microsoft.AspNetCore.Mvc;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeInstanceController : BaseController<AttributeInstance>
    {
        public AttributeInstanceController(RPGMakerContext context) : base(context)
        {
        }
    }
}
