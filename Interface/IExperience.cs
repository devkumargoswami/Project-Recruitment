using Project_Recruitment.DTOs;
using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface IExperience
    {
        public void  InsertExperience(ExperienceDTO dto);
       public void  UpdateExperience(ExperienceUpdateDTO dto);
        public void DeleteExperience(int experienceId);
       public Task<List<Experience>> GetExperienceByUser(int userId);
    }
}
