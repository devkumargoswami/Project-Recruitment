using Dapper;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System.Data;

namespace Project_Recruitment.Business
{
    public class UserEducationBusines : IUserEducationRepository
    {
        private readonly IDbConnection _db;

        public UserEducationBusines(IDbConnection db)
        {
            _db = db;
        }

        // INSERT
        public void InsertEducation(UserEducationEntity education)
        {
            try
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

                _db.Execute("SP_Education_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting education: {ex.Message}");
            }
        }

        // SELECT
        public List<UserEducationEntity> GetEducationByUserId(int userId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);

                var result = _db.Query<UserEducationEntity>(
                    "SP_Education_Select",
                    parameters,
                    commandType: CommandType.StoredProcedure
                ).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching education: {ex.Message}");
            }
        }

        // UPDATE
        public int UpdateEducation(UserEducationEntity education)
        {
            try
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

                int rowsUpdated = _db.QueryFirstOrDefault<int>(
                    "SP_Education_Update",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return rowsUpdated;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating education: {ex.Message}");
            }
        }

        // DELETE
        public void DeleteEducation(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                _db.Execute("SP_Education_Delete",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting education: {ex.Message}");
            }
        }
    }
}
