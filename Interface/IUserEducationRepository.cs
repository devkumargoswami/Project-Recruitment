using Project_Recruitment.Entity;
using System.Collections.Generic;

namespace Project_Recruitment.Interface
{
    public interface IUserEducationRepository
    {
        public void InsertEducation(UserEducationEntity education);

        public List<UserEducationEntity> GetEducationByUserId(int userId);

        public int UpdateEducation(UserEducationEntity education);

        public void DeleteEducation(int id);
    }
}
