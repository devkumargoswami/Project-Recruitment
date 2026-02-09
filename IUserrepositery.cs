namespace Project_Recruitment
{
    public interface IUserrepositery
    {
        void AddUser(UserEntity user);
        IEnumerable<UserEntity> GetUsers();

    }
}
