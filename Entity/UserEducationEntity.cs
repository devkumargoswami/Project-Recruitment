namespace Project_Recruitment.Entity
{
    public class UserEducationEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EducationLevelId { get; set; }
        public string SchoolCollege { get; set; }
        public string BoardUniversity { get; set; }
        public string Degree { get; set; }
        public int StartMonth { get; set; }
        public int StartYear { get; set; }
        public int? EndMonth { get; set; }
        public int? EndYear { get; set; }
        public bool IsContinue { get; set; }
    }
}
