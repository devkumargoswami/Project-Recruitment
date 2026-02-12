using System.Data;
using Microsoft.Data.SqlClient;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
namespace Project_Recruitment.Business
{
    public class InterviewScheduleRepository : IInterviewScheduleRepository
    {
        private readonly IConfiguration _configuration;

        public InterviewScheduleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        // INSERT
        public void Insert(InterviewSchedule model)
        {
            using SqlConnection con = GetConnection();
            using SqlCommand cmd = new SqlCommand("SP_InterviewSchedule_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", model.UserId);
            cmd.Parameters.AddWithValue("@InterviewTitle", model.InterviewTitle);
            cmd.Parameters.AddWithValue("@InterviewDateTime", model.InterviewDateTime);
            cmd.Parameters.AddWithValue("@InterviewBy", model.InterviewBy);
            cmd.Parameters.AddWithValue("@Status", model.Status);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // UPDATE
        public void Update(InterviewSchedule model)
        {
            using SqlConnection con = GetConnection();
            using SqlCommand cmd = new SqlCommand("SP_InterviewSchedule_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", model.Id);
            cmd.Parameters.AddWithValue("@UserId", model.UserId);
            cmd.Parameters.AddWithValue("@InterviewTitle", model.InterviewTitle);
            cmd.Parameters.AddWithValue("@InterviewDateTime", model.InterviewDateTime);
            cmd.Parameters.AddWithValue("@InterviewBy", model.InterviewBy);
            cmd.Parameters.AddWithValue("@Status", model.Status);
            cmd.Parameters.AddWithValue("@Comments", model.Comments ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@RecordingPath", model.RecordingPath ?? (object)DBNull.Value);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int id)
        {
            using SqlConnection con = GetConnection();
            using SqlCommand cmd = new SqlCommand("SP_InterviewSchedule_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // SELECT
        public List<InterviewSchedule> GetByUserId(int userId)
        {
            List<InterviewSchedule> list = new();

            using SqlConnection con = GetConnection();
            using SqlCommand cmd = new SqlCommand("SP_InterviewSchedule_Select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new InterviewSchedule
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    UserId = Convert.ToInt32(dr["UserId"]),
                    InterviewTitle = dr["InterviewTitle"].ToString(),
                    InterviewDateTime = Convert.ToDateTime(dr["InterviewDateTime"]),
                    InterviewBy = dr["InterviewBy"].ToString(),
                    Status = dr["Status"].ToString(),
                    Comments = dr["Comments"]?.ToString(),
                    RecordingPath = dr["RecordingPath"]?.ToString()
                });
            }
            return list;
        }
    }
}
