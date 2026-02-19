using Dapper;
using Project_Recruitment.DTOs;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System.Data;

namespace Project_Recruitment.Business
{
    public class ExperienceBusiness : IExperience
    {
        private readonly IDbConnection db;

        public ExperienceBusiness(IDbConnection db)
        {
            this.db = db;
        }

        // INSERT
        public void InsertExperience(ExperienceDTO dto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", dto.UserId);
            parameters.Add("@CompanyName", dto.CompanyName);
            parameters.Add("@Designation", dto.Designation);
            parameters.Add("@StartDate", dto.StartDate);
            parameters.Add("@EndDate", dto.EndDate);
            parameters.Add("@IsCurrent", dto.IsCurrent);

            db.ExecuteAsync(
                "SP_Experience_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
            );


        }

        // UPDATE
        public void  UpdateExperience(ExperienceUpdateDTO dto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ExperienceId", dto.ExperienceId);
            parameters.Add("@UserId", dto.UserId);
            parameters.Add("@CompanyName", dto.CompanyName);
            parameters.Add("@Designation", dto.Designation);
            parameters.Add("@StartDate", dto.StartDate);
            parameters.Add("@EndDate", dto.EndDate);
            parameters.Add("@IsCurrent", dto.IsCurrent);

            db.Execute("SP_Experience_Update", parameters, commandType: CommandType.StoredProcedure);

        }

        // DELETE
        public void DeleteExperience(int experienceId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ExperienceId", experienceId);

            db.ExecuteAsync(
                "SP_Experience_Delete",
                parameters,
                commandType: CommandType.StoredProcedure
            );

        }

        // SELECT
        public async Task<List<Experience>> GetExperienceByUser(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);

            var result = await db.QueryAsync<Experience>(
                "SP_Experience_Select",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
    }
}
