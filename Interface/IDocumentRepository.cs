using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface IDocumentRepository
    {
        public void InsertDocument(DocumentEntity document);
        public List<DocumentEntity> GetDocumentsByUserId(int userId);
        public void UpdateDocument(DocumentEntity document);
        public void DeleteDocument(int documentId);
    }
}
