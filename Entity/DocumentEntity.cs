namespace Project_Recruitment.Entity
{
    public class DocumentEntity
    {
        public int DocumentId { get; set; }
        public int UserId { get; set; }
        public required string DocumentName { get; set; }
        public required string DocumentPath { get; set; }
        public DateTime CreateDatetime { get; set; }
    }
}
