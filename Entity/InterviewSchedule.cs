namespace Project_Recruitment.Entity
{
    public class InterviewSchedule
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string InterviewTitle { get; set; }
        public DateTime InterviewDateTime { get; set; }
        public string? InterviewBy { get; set; }
        public int Status { get; set; }
        public string? Comments { get; set; }
        public string? RecordingPath { get; set; }
    }
}
