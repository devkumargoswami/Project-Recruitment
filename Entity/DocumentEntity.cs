namespace Project_Recruitment.Entity
{
    public class DocumentEntity
    {
        public int DocumentId { get; set; }
        public int UserId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public DateTime CreateDatetime { get; set; }
    }
}
