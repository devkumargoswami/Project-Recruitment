using System.Collections.Generic;

namespace Project_Recruitment
{
    public interface IUserrepositery
    {
       
        // Login user
        UserEntity Login(string email, string password);

        // Update user password
        void UpdatePassword(int userId, string newPassword, string confirmPassword);
    }
}
