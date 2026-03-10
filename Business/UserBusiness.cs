using Dapper;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project_Recruitment.Business
{
    public class UserBusiness : IUserrepositery
    {
        private readonly IDbConnection dbConnection;

        public UserBusiness(IDbConnection dbconnection)
        {
            dbConnection = dbconnection;
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

            var parameters = new DynamicParameters();
            parameters.Add("@Username", user.Username);
            parameters.Add("@Password", user.Password);
            parameters.Add("@Email", user.Email);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Gender", user.Gender);
            parameters.Add("@PhoneNumber", user.PhoneNumber);
            parameters.Add("@DateOfBirth", user.DateOfBirth);
            parameters.Add("@Address", user.Address);
            parameters.Add("@CountryId", user.CountryId);
            parameters.Add("@StateId", user.StateId);
            parameters.Add("@City", user.City);
            parameters.Add("@InterviewStatus", user.InterviewStatus);
            parameters.Add("@RoleId", user.RoleId);
            parameters.Add("@OfferCTC", user.OfferCTC);
            parameters.Add("@TotalExperience", user.TotalExperience);
            parameters.Add("@CreatedDateTime",
                user.CreatedDateTime == default ? DateTime.Now : user.CreatedDateTime);

            dbConnection.Execute("SP_User_Insert", parameters, commandType: CommandType.StoredProcedure);
        
        }

        // =========================
        // UPDATE USER
        // =========================
        public void UpdateUser(UserEntity user)
        {
            if (user.Id <= 0)
                throw new Exception("Valid User Id is required");

            var parameters = new DynamicParameters();
            parameters.Add("@Id", user.Id);
            parameters.Add("@Username", user.Username);
            parameters.Add("@Email", user.Email);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Gender", user.Gender);
            parameters.Add("@PhoneNumber", user.PhoneNumber);
            parameters.Add("@DateOfBirth", user.DateOfBirth);
            parameters.Add("@Address", user.Address);
            parameters.Add("@CountryId", user.CountryId);
            parameters.Add("@StateId", user.StateId);
            parameters.Add("@City", user.City);
            parameters.Add("@InterviewStatus", user.InterviewStatus);
            parameters.Add("@RoleId", user.RoleId);
            parameters.Add("@OfferCTC", user.OfferCTC);
            parameters.Add("@TotalExperience", user.TotalExperience);

            dbConnection.Execute("SP_User_Update", parameters, commandType: CommandType.StoredProcedure);
        }

        // =========================
        // DELETE USER
        // =========================
        public void DeleteUser(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid User Id");

            dbConnection.Execute(
                "SP_User_Delete",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        // =========================
        // GET ALL USERS
        // =========================
        public IEnumerable<UserEntity> GetUsers()
        {
            return dbConnection.Query<UserEntity>("SELECT * FROM [User]");
        }

        // =========================
        // LOGIN
        // =========================
        public UserEntity Login(string email, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);
            parameters.Add("@Password", password);

            var user = dbConnection.QueryFirstOrDefault<UserEntity>(
                "SP_User_Login",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            if (user != null)
            {
                if (email.Equals("hries@gmail.com", StringComparison.OrdinalIgnoreCase))
                {
                    user.RoleId = 1; // HR
                }
                else
                {
                    user.RoleId = 4; // Candidate
                }
            }

            return user;
        }
        // =========================
        // UPDATE PASSWORD
        // =========================
        public void UpdatePassword(int? userId, string? email, string newPassword, string confirmPassword)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@UserId", userId);
            parameters.Add("@Email", email);
            parameters.Add("@NewPassword", newPassword);
            parameters.Add("@ConfirmPassword", confirmPassword);

            parameters.Add("@ReturnValue",
                dbType: DbType.Int32,
                direction: ParameterDirection.ReturnValue);

            dbConnection.Execute(
                "SP_Forgot_Password",
                parameters,
                commandType: CommandType.StoredProcedure);

            int result = parameters.Get<int>("@ReturnValue");

            switch (result)
            {
                case -1:
                    throw new Exception("Passwords do not match");

                case -2:
                    throw new Exception("UserId or Email is required");

                case -3:
                    throw new Exception("UserId not found");

                case -4:
                    throw new Exception("Email not found");

                case 1:
                    return;

                default:
                    throw new Exception("Password update failed");
            }
        }
    }
}