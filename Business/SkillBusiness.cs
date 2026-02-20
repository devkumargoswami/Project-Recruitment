using Microsoft.Data.SqlClient;
using System.Data;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Business
{
    public class SkillBussiness : ISkillRepository
    {
        private readonly IConfiguration _configuration;

        public SkillBussiness(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        // INSERT
        public int InsertSkill(SkillEntity skill)
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_Skill_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", skill.UserId);
                cmd.Parameters.AddWithValue("@Name", skill.Name);

                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // SELECT
        public List<SkillEntity> GetSkill(int? id, int? userId)
        {
            List<SkillEntity> list = new List<SkillEntity>();

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_Skill_Select", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", (object)id ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UserId", (object)userId ?? DBNull.Value);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new SkillEntity() 
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        Name = dr["Name"].ToString()
                    });
                }
            }

            return list;
        }

        // DELETE
        public void DeleteSkill(int id)
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_Skill_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
