namespace Project_Recruitment.Entity
{
    public class UserRegisterEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal OfferCTC { get; set; }

        public int RoleId { get; set; }
    }
}
