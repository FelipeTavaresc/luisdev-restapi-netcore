using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.Skill.GetAllSkills
{
    public class GetAllSkillsHandler : IRequestHandler<GetAllSkillsQuery, ResultViewModel<List<SkillItemViewModel>>>
    {
        private readonly DevFreelaDbContext _context;

        public GetAllSkillsHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<SkillItemViewModel>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var skills = await _context.Skills
                    .Where(s => !s.IsDeleted)
                    .ToListAsync();

                var model = skills.Select(SkillItemViewModel.FromEntity).ToList();

                return ResultViewModel<List<SkillItemViewModel>>.Success(model);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
