using Microsoft.AspNetCore.Mvc;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumOptionController : BaseController<EnumOption>
    {
        public EnumOptionController(RPGMakerContext context) : base(context)
        {
        }
    }
}
