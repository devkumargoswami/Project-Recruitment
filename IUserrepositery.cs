using Project_Recruitment.Models;

namespace Project_Recruitment.Repository
{
    public interface IUserrepositery
    {
        void AddUser(UserEntity user);
        void UpdateUser(UserEntity user);
        void DeleteUser(int userId);

       void getUsers();

    }
}
