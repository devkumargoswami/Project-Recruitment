using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface IEducationLevelRepository
    {
        public int Insert(EducationLevelEntity entity);
        public EducationLevelEntity GetById(int id);
        public int Update(EducationLevelEntity entity);
        public int Delete(int id);
    }
}
