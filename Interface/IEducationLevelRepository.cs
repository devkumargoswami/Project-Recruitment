using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface IEducationLevelRepository
    {
        int Insert(EducationLevelEntity entity);
        EducationLevelEntity GetById(int id);
        int Update(EducationLevelEntity entity);
        int Delete(int id);
    }
}
