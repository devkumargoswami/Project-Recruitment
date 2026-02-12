using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface IInterviewScheduleRepository
    {
        void Insert(InterviewSchedule model);
        void Update(InterviewSchedule model);
        void Delete(int id);
        List<InterviewSchedule> GetByUserId(int userId);
    }
}
