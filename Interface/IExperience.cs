using Project_Recruitment.DTOs;
using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface IExperience
    {
        Task<bool> InsertExperience(ExperienceDTO dto);
        Task<bool> UpdateExperience(ExperienceUpdateDTO dto);
        Task<bool> DeleteExperience(int experienceId);
        Task<List<Experience>> GetExperienceByUser(int userId);
    }
}
