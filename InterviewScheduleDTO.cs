namespace Project_Recruitment.DTO
{
    public class InterviewScheduleDTO
    {
        public int UserId { get; set; }
        public string InterviewTitle { get; set; }
        public DateTime InterviewDateTime { get; set; }
        public string InterviewBy { get; set; }
        public string Status { get; set; }
        public string? Comments { get; set; }
        public string? RecordingPath { get; set; }
    }
}
