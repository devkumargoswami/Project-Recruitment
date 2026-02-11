using Dapper;
using Project_Recruitment;
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

        

        public UserEntity Login(string email, string password)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Email", email);
                parameters.Add("@Password", password);

                // Stored procedure returns Id & Email on success
                var user = _db.QueryFirstOrDefault<UserEntity>(
                    "SP_User_Login",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
                return user;
            }
            catch (Exception ex)
            {
                // log exception here if needed
                throw new Exception($"Login failed: {ex.Message}");
            }
        }


        public void UpdatePassword(int userId, string newPassword, string confirmPassword)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                parameters.Add("@NewPassword", newPassword);
                parameters.Add("@ConfirmPassword", confirmPassword);

                // Capture RETURN value from stored procedure
                parameters.Add(
                    "@ReturnValue",
                    dbType: DbType.Int32,
                    direction: ParameterDirection.ReturnValue
                );

                _db.Execute(
                    "SP_Forgot_Password",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                int result = parameters.Get<int>("@ReturnValue");

                if (result == -1)
                    throw new Exception("New password and confirm password do not match.");

                if (result != 1)
                    throw new Exception("Password update failed.");
            }
            catch (Exception ex)
            {
                // log exception here if needed
                throw new Exception($"Error while updating password: {ex.Message}");
            }
        }

    }
}
