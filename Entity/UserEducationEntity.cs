namespace Project_Recruitment.Entity
{
    public class UserEducationEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EducationLevelId { get; set; }
        public required string SchoolCollege { get; set; }
        public required string BoardUniversity { get; set; }
        public required string Degree { get; set; }
        public int StartMonth { get; set; }
        public int StartYear { get; set; }
        public int? EndMonth { get; set; }
        public int? EndYear { get; set; }
        public bool IsContinue { get; set; }
    }
}
