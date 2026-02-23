using Dapper;
using Microsoft.AspNetCore.Components;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System.Data;

namespace Project_Recruitment.Business
{
    public class UserRegisterBusiness : IRegisterRepository
    {
        private readonly IDbConnection _db;

        public UserRegisterBusiness(IDbConnection db)
        {
            _db = db;
        }

        // REGISTER USER
        public int RegisterUser(UserRegisterEntity user)
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

            int status = _db.QueryFirstOrDefault<int>(
                "SP_User_Registration",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return status; // 1 = Success, 0 = Duplicate
        }
    }
}
