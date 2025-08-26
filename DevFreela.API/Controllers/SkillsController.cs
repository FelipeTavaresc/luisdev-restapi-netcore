using Microsoft.AspNetCore.Mvc;
using MediatR;
using DevFreela.Application.Commands.Skill.InsertSkill;
using DevFreela.Application.Queries.Skill.GetAllSkills;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            var query = new GetAllSkillsQuery();

            var result = _mediator.Send(query);

            return Ok(result);
        }

        // POST api/skills
        [HttpPost]
        public IActionResult Post(InsertSkillCommand command)
        {
            var result = _mediator.Send(command);

            return NoContent();
        }
    }
}
