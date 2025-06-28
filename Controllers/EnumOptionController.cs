using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnumOptionController : BaseController<EnumOption>
    {
        public EnumOptionController(RPGMakerContext context) : base(context)
        {
        }
    }
}
