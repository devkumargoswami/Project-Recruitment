using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface IRegisterRepository
    {
        int RegisterUser(UserRegisterEntity user);
    }
}
