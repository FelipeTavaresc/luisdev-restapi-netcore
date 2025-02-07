using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        // GET api/projects?search=crm
        [HttpGet]
        public IActionResult GetAll(string search) => Ok();


        // GET api/projects/123
        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok();

        // POST api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        // PUT api/projects/123
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model) 
        {
            return NoContent();
        }

        // DELETE api/projects/1234
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            return NoContent();
        }

        // PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        // PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            return NoContent();
        }

        // POST api/project/1234/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model)
        {
            return Ok();
        }
    }
}
