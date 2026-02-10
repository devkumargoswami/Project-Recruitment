using Project_Recruitment.Models;

namespace Project_Recruitment
{
    public interface IUserrepositery
    {
        // INSERT
        void AddUser(UserEntity user);

        // UPDATE
        void UpdateUser(UserEntity user);

        // DELETE
        void DeleteUser(int userId);

        // GET
        IEnumerable<UserEntity> GetUsers();
    }
}
