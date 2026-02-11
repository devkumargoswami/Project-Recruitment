using System.Collections.Generic;

namespace Project_Recruitment
{
    public interface IUserrepositery
    {
        void AddUser(UserEntity user);
        IEnumerable<UserEntity> GetUsers();
        void UpdateUser(UserEntity user);
        void DeleteUser(int id);



        // Login user
        UserEntity Login(string email, string password);

        // Update user password
        void UpdatePassword(int userId, string newPassword, string confirmPassword);

    }
}
