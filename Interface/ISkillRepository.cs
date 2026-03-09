using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface ISkillRepository
    {
        public int InsertSkill(SkillEntity skill);
        public int UpdateSkill(SkillEntity Skill);
        public List<SkillEntity> GetSkill(int? id, int? userId);
        public void DeleteSkill(int id);
    }
}
