using DevFreela.Application.Models;

namespace DevFreela.Application.Services.Skill
{
    public interface ISkillService
    {
        ResultViewModel<List<SkillItemViewModel>> GetAll();
        ResultViewModel<int> Insert(CreateSkillInputModel model);  
    }
}
