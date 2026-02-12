namespace Project_Recruitment.Entity
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrent { get; set; }
    }
}
