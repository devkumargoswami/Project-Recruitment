using Dapper;
using System.Data;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Business
{
    public class InterviewScheduleBusiness : IInterviewScheduleRepository
    {
        private readonly IDbConnection _interviewScheduleConnection;

        public InterviewScheduleBusiness(IDbConnection interviewScheduleConnection)
        {
            _interviewScheduleConnection = interviewScheduleConnection;
        }

        // INSERT
        public void Insert(InterviewSchedule model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", model.UserId);
            parameters.Add("@InterviewTitle", model.InterviewTitle);
            parameters.Add("@InterviewDateTime", model.InterviewDateTime);
            parameters.Add("@Comments", model.Comments);
            parameters.Add("@RecordingPath", model.RecordingPath);
            parameters.Add("@InterviewBy", model.InterviewBy);
            parameters.Add("@Status", model.Status);

            _interviewScheduleConnection.Execute(
                "SP_InterviewSchedule_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // UPDATE
        public void Update(InterviewSchedule model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", model.Id);
            parameters.Add("@UserId", model.UserId);
            parameters.Add("@InterviewTitle", model.InterviewTitle);
            parameters.Add("@InterviewDateTime", model.InterviewDateTime);
            parameters.Add("@InterviewBy", model.InterviewBy);
            parameters.Add("@Status", model.Status);
            parameters.Add("@Comments", model.Comments);
            parameters.Add("@RecordingPath", model.RecordingPath);

            _interviewScheduleConnection.Execute(
                "SP_InterviewSchedule_Update",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // DELETE
        public void Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            _interviewScheduleConnection.Execute(
                "SP_InterviewSchedule_Delete",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // SELECT
        public List<InterviewSchedule> GetByUserId(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);

            return _interviewScheduleConnection.Query<InterviewSchedule>(
                "SP_InterviewSchedule_Select",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }
    }
}
