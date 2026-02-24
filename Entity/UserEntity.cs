using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Recruitment.Entity
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(200)]
        public string Password { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string Gender { get; set; }

        [Column("Phonenumber")]
        public long? PhoneNumber { get; set; }

        [Required]
        [Column("DataOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public int? CountryId { get; set; }

        public int? StateId { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        public int RoleId { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal OfferCTC { get; set; }

        public int? InterviewStatus { get; set; }

        [Column(TypeName = "decimal(4,1)")]
        public decimal? TotalExperience { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}