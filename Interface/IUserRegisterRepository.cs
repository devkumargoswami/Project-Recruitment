using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface IUserRegisterRepository
    {
        public Task<int> RegisterUser(UserRegisterEntity user);
    }
}
