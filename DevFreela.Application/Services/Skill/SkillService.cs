using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Skill
{
    public class SkillService : ISkillService
    {
        public readonly DevFreelaDbContext _context;

        public SkillService(DevFreelaDbContext context) => _context = context;

        public ResultViewModel<List<SkillItemViewModel>> GetAll()
        {
            var skills = _context.Skills.ToList();

            var model = skills.Select(SkillItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<SkillItemViewModel>>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateSkillInputModel model)
        {
            var skill = model.ToEntity();

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(skill.Id);
        }
    }
}
