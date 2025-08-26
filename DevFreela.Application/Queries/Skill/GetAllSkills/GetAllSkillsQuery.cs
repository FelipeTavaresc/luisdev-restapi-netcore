using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.Skill.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<ResultViewModel<List<SkillItemViewModel>>>
    {
    }
}
