using Dapper;
using Project_Recruitment;
using System.Data;
using static Dapper.SqlMapper;

namespace WebApplication1
{
    public class UserBusiness : IUserrepositery
    {
        private readonly IDbConnection _db;

        public UserBusiness(IDbConnection db)
        {
            _db = db;
        }

        public void AddUser(UserEntity user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
                throw new Exception("Email is required");

            var parameters = new DynamicParameters();
            parameters.Add("@Username", user.Username);
            parameters.Add("@Password", user.Password);
            parameters.Add("@Email", user.Email);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@DateOfBirth", user.DateOfBirth);
            parameters.Add("@OfferCTC", user.OfferCTC);

            int status = _db.QuerySingle<int>(
                "SP_User_Registration",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            if (status == 0)
                throw new Exception("Username or Email already exists");
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            return _db.Query<UserEntity>(
                "SP_User_List",
                commandType: CommandType.StoredProcedure
            );
        }
    }

}