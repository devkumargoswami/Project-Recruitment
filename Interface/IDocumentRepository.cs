using Project_Recruitment.Entity;

namespace Project_Recruitment.Interface
{
    public interface IDocumentRepository
    {
        public void Insert(DocumentEntity document);
        public List<DocumentEntity> Get(int userId);
        public void Update(DocumentEntity document);
        public void Delete(int documentId);
    }
}
