using Project_Recruitment.Entity;
using System.Collections.Generic;

namespace Project_Recruitment.Interface
{
    public interface IUserrepositery
    {
        void AddUser(UserEntity user);
        IEnumerable<UserEntity> GetUsers();
        void UpdateUser(UserEntity user);
        void DeleteUser(int id);



        // Login user
        public UserEntity Login(string email, string password);

        // Update user password
        public void UpdatePassword(int userId, string newPassword, string confirmPassword);

    }
}
