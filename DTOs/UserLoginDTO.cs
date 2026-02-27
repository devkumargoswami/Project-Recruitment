namespace Project_Recruitment.DTOs
{
    public class UserLoginDTO
    {
        public string Email { get; set; } = "";

        public int RoleId { get; set; } = 0;
        public string Password { get; set; } = "";
    }
}
