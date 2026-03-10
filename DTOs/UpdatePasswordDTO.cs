namespace Project_Recruitment.DTOs
{
    public class UpdatePasswordDTO
    {
        public int? UserId { get; set; }   // FIX
        public string? Email { get; set; }
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
