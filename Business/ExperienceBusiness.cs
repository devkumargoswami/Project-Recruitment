using Microsoft.Data.SqlClient;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System.Data;

namespace Project_Recruitment.Business
{
    public class ExperienceBusiness : IExperience
    {
        private readonly IConfiguration _configuration;

        public ExperienceBusiness(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));
        }

        // INSERT
        public async Task<bool> InsertExperience(ExperienceDTO dto)
        {
            await using SqlConnection con = GetConnection();
            await using SqlCommand cmd = new SqlCommand("SP_Experience_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dto.UserId;
            cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 100).Value = dto.CompanyName;
            cmd.Parameters.Add("@Designation", SqlDbType.NVarChar, 100).Value = dto.Designation;
            cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = dto.StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value =
                dto.EndDate ?? (object)DBNull.Value;
            cmd.Parameters.Add("@IsCurrent", SqlDbType.Bit).Value = dto.IsCurrent;

            await con.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        // UPDATE
        public async Task<bool> UpdateExperience(ExperienceUpdateDTO dto)
        {
            await using SqlConnection con = GetConnection();
            await using SqlCommand cmd = new SqlCommand("SP_Experience_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dto.UserId;
            cmd.Parameters.Add("@ExperienceId", SqlDbType.Int).Value = dto.ExperienceId;
            cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 100).Value = dto.CompanyName;
            cmd.Parameters.Add("@Designation", SqlDbType.NVarChar, 100).Value = dto.Designation;
            cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = dto.StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value =
                dto.EndDate ?? (object)DBNull.Value;
            cmd.Parameters.Add("@IsCurrent", SqlDbType.Bit).Value = dto.IsCurrent;

            await con.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        // DELETE
        public async Task<bool> DeleteExperience(int experienceId)
        {
            await using SqlConnection con = GetConnection();
            await using SqlCommand cmd = new SqlCommand("SP_Experience_Delete", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@ExperienceId", SqlDbType.Int).Value = experienceId;

            await con.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        // SELECT
        public async Task<List<Experience>> GetExperienceByUser(int userId)
        {
            List<Experience> list = new();

            await using SqlConnection con = GetConnection();
            await using SqlCommand cmd = new SqlCommand("SP_Experience_Select", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

            await con.OpenAsync();
            await using SqlDataReader dr = await cmd.ExecuteReaderAsync();

            while (await dr.ReadAsync())
            {
                list.Add(new Experience
                {
                    ExperienceId = dr.GetInt32("ExperienceId"),
                    UserId = dr.GetInt32("UserId"),
                    CompanyName = dr["CompanyName"]?.ToString(),
                    Designation = dr["Designation"]?.ToString(),
                    StartDate = dr.GetDateTime("StartDate"),
                    EndDate = dr["EndDate"] == DBNull.Value ? null : dr.GetDateTime("EndDate"),
                    IsCurrent = dr.GetBoolean("IsCurrent")
                });
            }

            return list;
        }
    }
}
