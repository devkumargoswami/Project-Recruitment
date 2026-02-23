using Project_Recruitment.Entity;
using System.Collections.Generic;

namespace Project_Recruitment.Interface
{
    public interface IUserEducationRepository
    {
        public void Insert(UserEducationEntity education);

        public List<UserEducationEntity> Get(int userId);

        public int Update(UserEducationEntity education);

        public void Delete(int id);
    }
}
