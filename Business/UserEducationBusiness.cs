using Dapper;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System.Data;

namespace Project_Recruitment.Business
{
    public class UserEducationBusiness : IUserEducationRepository
    {
        private readonly IDbConnection EducationConnection;

        public UserEducationBusiness(IDbConnection userEducationConnection)
        {
            EducationConnection = userEducationConnection;
        }

        // INSERT
        public void InsertEducation(UserEducationEntity education)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", education.UserId);
            parameters.Add("@EducationLevelId", education.EducationLevelId);
            parameters.Add("@BoardUniversity", education.BoardUniversity);
            parameters.Add("@SchoolCollege", education.SchoolCollege);
            parameters.Add("@Degree", education.Degree);
            parameters.Add("@StartMonth", education.StartMonth);
            parameters.Add("@StartYear", education.StartYear);
            parameters.Add("@EndMonth", education.EndMonth);
            parameters.Add("@EndYear", education.EndYear);
            parameters.Add("@IsContinue", education.IsContinue);

            EducationConnection.Execute(
                "SP_Education_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // SELECT
        public List<UserEducationEntity> GetEducationByUserId(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);

            return EducationConnection.Query<UserEducationEntity>(
                "SP_Education_Select",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        // UPDATE
        public int UpdateEducation(UserEducationEntity education)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EducationId", education.Id);
            parameters.Add("@UserId", education.UserId);
            parameters.Add("@EducationLevelId", education.EducationLevelId);
            parameters.Add("@SchoolCollege", education.SchoolCollege);
            parameters.Add("@BoardUniversity", education.BoardUniversity);
            parameters.Add("@Degree", education.Degree);
            parameters.Add("@StartMonth", education.StartMonth);
            parameters.Add("@StartYear", education.StartYear);
            parameters.Add("@EndMonth", education.EndMonth);
            parameters.Add("@EndYear", education.EndYear);
            parameters.Add("@IsContinue", education.IsContinue);

            return EducationConnection.QueryFirstOrDefault<int>(
                "SP_Education_Update",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // DELETE
        public void DeleteEducation(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            EducationConnection.Execute(
                "SP_Education_Delete",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
