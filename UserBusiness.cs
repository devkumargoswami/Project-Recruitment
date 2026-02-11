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

        // =========================
        // INSERT USER
        // =========================
        public void AddUser(UserEntity user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new Exception("Username is required");

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new Exception("Email is required");

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Username", user.Username);
                parameters.Add("@Password", user.Password);
                parameters.Add("@Email", user.Email);
                parameters.Add("@FirstName", user.FirstName);
                parameters.Add("@LastName", user.LastName);
                parameters.Add("@DateOfBirth", user.DateOfBirth);
                parameters.Add("@OfferCTC", user.OfferCTC);
                parameters.Add("@RoleId", user.RoleId);
        

        public UserEntity Login(string email, string password)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Email", email);
                parameters.Add("@Password", password);

                _db.Execute(
                    "SP_User_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting user", ex);
            }
        }

        // =========================
        // UPDATE USER
        // =========================
        public void UpdateUser(UserEntity user)
        {
            if (user.UserId <= 0)
                throw new Exception("Valid UserId is required for update");

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", user.UserId);
                parameters.Add("@Username", user.Username);
                parameters.Add("@Email", user.Email);
                parameters.Add("@FirstName", user.FirstName);
                parameters.Add("@LastName", user.LastName);
   
                parameters.Add("@RoleId", user.RoleId);

                _db.Execute(
                    "SP_User_Update",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating user", ex);
            }
        }

        // =========================
        // DELETE USER
        // =========================
        public void DeleteUser(int id)
        {
            if (id <= 0)
                throw new Exception("Valid UserId is required for delete");

            try
            {
                _db.Execute(
                    "SP_User_Delete",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting user", ex);
            }
        }
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
