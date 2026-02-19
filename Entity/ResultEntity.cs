namespace Project_Recruitment.Entity
{
    public class Result
    {
        public int Result_id { get; set; }
        public int Candidate_id { get; set; }
        public int Technical_marks { get; set; }
        public int Hr_marks { get; set; }
        public int Total { get; set; }
        public string? Status { get; set; }
    }
}
