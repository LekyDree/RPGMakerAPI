using Microsoft.AspNetCore.Mvc;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilityInstanceController : BaseController<AbilityInstance>
    {
        public AbilityInstanceController(RPGMakerContext context) : base(context)
        {
        }
    }
}
