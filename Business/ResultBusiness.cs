using Microsoft.Data.SqlClient;
using System.Data;
using Project_Recruitment.Interface;
using Project_Recruitment.DTOs;
using Project_Recruitment.Entity;

namespace Project_Recruitment.Business
{
    public class ResultBussiness : IResultRepositry
    {
        private readonly IConfiguration _configuration;

        public ResultBussiness(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Insert(ResultDTO model)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using SqlCommand cmd = new SqlCommand("SP_Result_Insert", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@candidate_id", model.Candidate_id);
            cmd.Parameters.AddWithValue("@technical_marks", model.Technical_marks);
            cmd.Parameters.AddWithValue("@hr_marks", model.Hr_marks);

            con.Open();
            cmd.ExecuteNonQuery();

            return "Inserted Successfully";
        }

        public string Update(ResultDTO model)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using SqlCommand cmd = new SqlCommand("SP_Result_Update", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@result_id", model.Result_id);
            cmd.Parameters.AddWithValue("@technical_marks", model.Technical_marks);
            cmd.Parameters.AddWithValue("@hr_marks", model.Hr_marks);
            cmd.Parameters.AddWithValue("@candidate_id", model.Candidate_id);

            con.Open();
            cmd.ExecuteNonQuery();

            return "Updated Successfully";
        }

        public List<Result> GetByCandidate(int candidateId)
        {
            List<Result> list = new();

            using SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using SqlCommand cmd = new SqlCommand("SP_Result_Selecte", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@candidate_id", candidateId);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Result
                {
                    Result_id = Convert.ToInt32(reader["result_id"]),
                    Candidate_id = Convert.ToInt32(reader["candidate_id"]),
                    Technical_marks = Convert.ToInt32(reader["technical_marks"]),
                    Hr_marks = Convert.ToInt32(reader["hr_marks"]),
                    Total = Convert.ToInt32(reader["total"]),
                    Status = reader["status"].ToString()
                });
            }

            return list;
        }

        public string Delete(int id)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using SqlCommand cmd = new SqlCommand("SP_Result_Delete", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@result_id", id);

            con.Open();
            cmd.ExecuteNonQuery();

            return "Deleted Successfully";
        }
    }
}
