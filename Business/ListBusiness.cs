using Microsoft.Data.SqlClient;
using Project_Recruitment.DTOs;
using System.Data;

namespace Project_Recruitment.Business
{
    public class ListBusiness : IListrepositery
    {
        private readonly IConfiguration _configuration;

        public ListBusiness(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<UserListDTO> GetAllUsers(int id)
        {
            List<UserListDTO> list = new();

            using SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using SqlCommand cmd = new SqlCommand("SP_User_List", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new UserListDTO
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Username = reader["Username"].ToString(),
                    Email = reader["Email"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Phonenumber = reader["Phonenumber"].ToString(),
                    RoleId = Convert.ToInt32(reader["RoleId"]),
                    CreatedDateTime = Convert.ToDateTime(reader["CreatedDateTime"])
                });
            }

            return list;
        }

    }
}
