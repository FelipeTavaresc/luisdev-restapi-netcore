﻿using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;

        public UsersController(DevFreelaDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var user = _context.Users
                .Include(u => u.Skills)
                    .ThenInclude(u => u.Skill)
                .SingleOrDefault(u => u.Id == id);

            if(user is null)
                return NotFound();

            var model = UserViewModel.FromEntity(user);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var user = new User(model.FullName, model.Email, model.BirthDate);

            _context.Users.Add(user);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("{id}/skills")]
        public IActionResult PostSkills(int id, UserSkillsInputModel model)
        {
            var userSkills = model.SkillIds.Select(s => new UserSkill(id, s)).ToList();

            _context.UserSkills.AddRange(userSkills);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(IFormFile file)
        {
            var description = $"File: {file.FileName}, Size: {file.Length}";
            return Ok(description);
        }
    }
}
