using DevFreela.Application.Models;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Services.Skill;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService) => _skillService = skillService;


        // GET api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            var skills = _skillService.GetAll();
            return Ok(skills);
        }

        // POST api/skills
        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model)
        {
            var result = _skillService.Insert(model);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
