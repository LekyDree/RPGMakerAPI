using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeTemplateController : BaseController<AttributeTemplate>
    {
        public AttributeTemplateController(RPGMakerContext context) : base(context)
        {
        }
    }
}
