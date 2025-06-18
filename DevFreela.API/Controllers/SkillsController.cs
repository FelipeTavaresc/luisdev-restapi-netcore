using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        // GET api/skills
        [HttpGet]
        public IActionResult GetAll() => Ok();

        // POST api/skills
        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model) => Ok();
    }
}
