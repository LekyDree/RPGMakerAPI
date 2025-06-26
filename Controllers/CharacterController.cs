using Microsoft.AspNetCore.Mvc;
using RPGMakerAPI.Data;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : BaseController<Character>
    {
        public CharacterController(RPGMakerContext context) : base(context)
        {
        }
    }
}
