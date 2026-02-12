using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface IDocumentRepository
    {
        void InsertDocument(DocumentEntity document);
        List<DocumentEntity> GetDocumentsByUserId(int userId);
        void UpdateDocument(DocumentEntity document);
        void DeleteDocument(int documentId);
    }
}
