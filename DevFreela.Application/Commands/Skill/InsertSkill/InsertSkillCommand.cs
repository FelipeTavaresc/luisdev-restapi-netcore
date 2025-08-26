using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Skill.InsertSkill
{
    public class InsertSkillCommand : IRequest<ResultViewModel<int>>
    {
        public InsertSkillCommand(string description)
        {
            Description = description;
        }

        public string Description { get; set; }

        public Core.Entities.Skill ToEntity() => new(Description);
    }
}
