using Microsoft.AspNetCore.Mvc;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeTemplateController : BaseController<AttributeTemplate>
    {
        public AttributeTemplateController(RPGMakerContext context) : base(context)
        {
        }
    }
}
