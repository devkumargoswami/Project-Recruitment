using Dapper;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System.Data;

namespace Project_Recruitment.Business
{
    public class DocumentBusiness : IDocumentRepository
    {
        private readonly IDbConnection documentConnection;

        public DocumentBusiness(IDbConnection DocumentConnection)
        {
            documentConnection = DocumentConnection;
        }

        public void Insert(DocumentEntity document)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", document.UserId);
            parameters.Add("@DocumentName", document.DocumentName);
            parameters.Add("@DocumentPath", document.DocumentPath);

            documentConnection.Execute(
                "SP_Document_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public List<DocumentEntity> Get(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);

            return documentConnection.Query<DocumentEntity>(
                "SP_Document_Select",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        public void Update(DocumentEntity document)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DocumentId", document.DocumentId);
            parameters.Add("@DocumentName", document.DocumentName);
            parameters.Add("@DocumentPath", document.DocumentPath);

            documentConnection.Execute(
                "SP_Document_Update",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(int documentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DocumentId", documentId);

            documentConnection.Execute(
                "SP_Document_Delete",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
