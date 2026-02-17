namespace Project_Recruitment.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phonenumber { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
