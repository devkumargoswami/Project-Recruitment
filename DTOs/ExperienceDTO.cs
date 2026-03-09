namespace Project_Recruitment.DTOs
{
    public class ExperienceDTO
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string StartDate { get; set; }
        public string? EndDate { get; set; }
        public bool IsCurrent { get; set; }
    }

    public class ExperienceUpdateDTO : ExperienceDTO
    {
        public int Id { get; set; }  // Angular sends 'id'
    }
}