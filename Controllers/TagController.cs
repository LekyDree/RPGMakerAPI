using Microsoft.AspNetCore.Mvc;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : BaseController<Tag>
    {
        public TagController(RPGMakerContext context) : base(context)
        {
        }
    }
}
