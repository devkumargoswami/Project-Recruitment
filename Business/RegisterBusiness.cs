using Dapper;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System.Data;
using System.Threading.Tasks;

namespace Project_Recruitment.Business
{
    public class UserRegisterBusiness : IUserRegisterRepository
    {
        private readonly IDbConnection _db;

        public UserRegisterBusiness(IDbConnection db)
        {
            _db = db;
        }

        // REGISTER USER
        public async Task<int> RegisterUser(UserRegisterEntity user)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@Username", user.Username);
            parameters.Add("@Password", user.Password);
            parameters.Add("@Email", user.Email);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@DateOfBirth", user.DateOfBirth);
            parameters.Add("@Gender", user.Gender);
            parameters.Add("@PhoneNumber", user.PhoneNumber);
            parameters.Add("@Address", user.Address);
            parameters.Add("@CountryId", user.CountryId);
            parameters.Add("@StateId", user.StateId);
            parameters.Add("@OfferCTC", user.OfferCTC);
            parameters.Add("@RoleId", user.RoleId);
            parameters.Add("@TotalExperience", user.TotalExperience);


            int status = await _db.QueryFirstOrDefaultAsync<int>(
                "SP_User_Registration",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return status; 
        }
    }
}