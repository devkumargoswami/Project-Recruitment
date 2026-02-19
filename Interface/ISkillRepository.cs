using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface ISkillRepository
    {
        public int InsertSkill(Skill skill);
        public List<Skill> GetSkill(int? id, int? userId);
        public void DeleteSkill(int id);
    }
}
