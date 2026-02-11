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
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand("SP_Experience_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", dto.UserId);
            cmd.Parameters.AddWithValue("@CompanyName", dto.CompanyName);
            cmd.Parameters.AddWithValue("@Designation", dto.Designation);
            cmd.Parameters.AddWithValue("@StartDate", dto.StartDate);
            cmd.Parameters.AddWithValue("@EndDate",
                dto.EndDate == null ? DBNull.Value : dto.EndDate);
            cmd.Parameters.AddWithValue("@IsCurrent", dto.IsCurrent);

            con.Open();
            int row = await cmd.ExecuteNonQueryAsync();
            con.Close();

            return row > 0;
        }

        // UPDATE
        public async Task<bool> UpdateExperience(ExperienceUpdateDTO dto)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand("SP_Experience_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", dto.UserId);
            cmd.Parameters.AddWithValue("@ExperienceId", dto.ExperienceId);
            cmd.Parameters.AddWithValue("@CompanyName", dto.CompanyName);
            cmd.Parameters.AddWithValue("@Designation", dto.Designation);
            cmd.Parameters.AddWithValue("@StartDate", dto.StartDate);
            cmd.Parameters.AddWithValue("@EndDate",
                dto.EndDate == null ? DBNull.Value : dto.EndDate);
            cmd.Parameters.AddWithValue("@IsCurrent", dto.IsCurrent);

            con.Open();
            int row = await cmd.ExecuteNonQueryAsync();
            con.Close();

            return row > 0;
        }

        // DELETE
        public async Task<bool> DeleteExperience(int experienceId)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand("SP_Experience_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ExperienceId", experienceId);

            con.Open();
            int row = await cmd.ExecuteNonQueryAsync();
            con.Close();

            return row > 0;
        }

        // SELECT
        public async Task<List<Experience>> GetExperienceByUser(int userId)
        {
            List<Experience> list = new();

            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand("SP_Experience_Select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);

            con.Open();
            SqlDataReader dr = await cmd.ExecuteReaderAsync();

            while (await dr.ReadAsync())
            {
                Experience exp = new Experience();

                exp.ExperienceId = Convert.ToInt32(dr["ExperienceId"]);
                exp.UserId = Convert.ToInt32(dr["UserId"]);
                exp.CompanyName = dr["CompanyName"].ToString();
                exp.Designation = dr["Designation"].ToString();
                exp.StartDate = Convert.ToDateTime(dr["StartDate"]);
                exp.EndDate = dr["EndDate"] == DBNull.Value
                                ? null
                                : Convert.ToDateTime(dr["EndDate"]);
                exp.IsCurrent = Convert.ToBoolean(dr["IsCurrent"]);

                list.Add(exp);
            }

            con.Close();
            return list;
        }
    }
}
