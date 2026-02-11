using Project_Recruitment.Entity;
using System.Collections.Generic;

namespace Project_Recruitment.Interface
{
    public interface IUserEducationRepository
    {
        void InsertEducation(UserEducationEntity education);

        List<UserEducationEntity> GetEducationByUserId(int userId);

        int UpdateEducation(UserEducationEntity education);

        void DeleteEducation(int id);
    }
}
