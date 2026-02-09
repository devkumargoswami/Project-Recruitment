using Dapper;
using Project_Recruitment.Models;
using System.Data;

namespace WebApplication1
{
    public class UserBusiness : IUserrepositery
    {
        private readonly IDbConnection _db;

        public UserBusiness(IDbConnection db)
        {
            _db = db;
        }

        // 🔹 INSERT
        public void AddUser(UserEntity user)

        {
            var parameters = new DynamicParameters();
            parameters.Add("@Username", user.Username);
            parameters.Add("@Password", user.Password);
            parameters.Add("@Email", user.Email);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Phonenumber", user.Phonenumber);
            parameters.Add("@DateOfBirth", user.DateOfBirth);
            parameters.Add("@OfferCTC", user.OfferCTC);
            parameters.Add("@RoleId", user.RoleId);

            _db.Execute(
                "SP_User_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // 🔹 UPDATE
        public void UpdateUser(UserEntity user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", user.UserId);
            parameters.Add("@Username", user.Username);
            parameters.Add("@Email", user.Email);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Phonenumber", user.Phonenumber);
            parameters.Add("@RoleId", user.RoleId);

            _db.Execute(
                "SP_User_Update",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // 🔹 DELETE
        public void DeleteUser(int id)
        {
            _db.Execute(
                "SP_User_Delete",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        // 🔹 GET
        public IEnumerable<UserEntity> GetUsers()
        {
            return _db.Query<UserEntity>(
                "SP_User_List",
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
