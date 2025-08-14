using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class SkillViewModel
    {
        public SkillViewModel(int id, string description, List<UserSkill> userSkills)
        {
            Id = id;
            Description = description;
            UserSkills = userSkills;
        }

        public int Id { get; private set; }
        public string Description { get; set; }
        public List<UserSkill> UserSkills { get; set; }

        public static SkillViewModel FromEntity(Skill entity)
        {
            return new(entity.Id, entity.Description, entity.UserSkills);
        }
    }
}
