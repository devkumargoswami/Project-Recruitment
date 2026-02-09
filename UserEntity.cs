using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Recruitment
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }   // assuming PK exists

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [Column("DataOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal OfferCTC { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }
}
