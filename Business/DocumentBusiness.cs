using Dapper;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System.Data;

namespace Project_Recruitment.Business
{
    public class DocumentBusiness : IDocumentRepository
    {
        private readonly IDbConnection _documentConnection;

        public DocumentBusiness(IDbConnection documentConnection)
        {
            _documentConnection = documentConnection;
        }

        // INSERT
        public void InsertDocument(DocumentEntity document)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", document.UserId);
            parameters.Add("@DocumentName", document.DocumentName);
            parameters.Add("@DocumentPath", document.DocumentPath);

            _documentConnection.Execute(
                "SP_Document_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // SELECT
        public List<DocumentEntity> GetDocumentsByUserId(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);

            return _documentConnection.Query<DocumentEntity>(
                "SP_Document_Select",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        // UPDATE
        public void UpdateDocument(DocumentEntity document)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DocumentId", document.DocumentId);
            parameters.Add("@DocumentName", document.DocumentName);
            parameters.Add("@DocumentPath", document.DocumentPath);

            _documentConnection.Execute(
                "SP_Document_Update",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // DELETE
        public void DeleteDocument(int documentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DocumentId", documentId);

            _documentConnection.Execute(
                "SP_Document_Delete",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
