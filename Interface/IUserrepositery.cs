using Project_Recruitment.Entity;
using System.Collections.Generic;

namespace Project_Recruitment.Interface
{
    public interface IUserrepositery
    {
       
        // Login user
        UserEntity Login(string email, string password);

        // Update user password
        void UpdatePassword(int userId, string newPassword, string confirmPassword);
    }
}
