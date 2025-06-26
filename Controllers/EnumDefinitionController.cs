using Microsoft.AspNetCore.Mvc;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumDefinitionController : BaseController<EnumDefinition>
    {
        public EnumDefinitionController(RPGMakerContext context) : base(context)
        {
        }
    }
}
