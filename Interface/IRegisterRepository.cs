using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface IRegisterRepository
    {
        public int RegisterUser(UserRegisterEntity user);
    }
}
