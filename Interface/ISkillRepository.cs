using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface ISkillRepository
    {
        int InsertSkill(Skill skill);
        List<Skill> GetSkill(int? id, int? userId);
        void DeleteSkill(int id);
    }
}
