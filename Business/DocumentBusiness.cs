using Dapper;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System.Data;

namespace Project_Recruitment.Business
{
    public class DocumentBusiness : IDocumentRepository
    {
        private readonly IDbConnection _db;

        public DocumentBusiness(IDbConnection db)
        {
            _db = db;
        }

        // INSERT
        public void InsertDocument(DocumentEntity document)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", document.UserId);
                parameters.Add("@DocumentName", document.DocumentName);
                parameters.Add("@DocumentPath", document.DocumentPath);

                _db.Execute("SP_Document_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting document: {ex.Message}");
            }
        }

        // SELECT
        public List<DocumentEntity> GetDocumentsByUserId(int userId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);

                var result = _db.Query<DocumentEntity>(
                    "SP_Document_Select",
                    parameters,
                    commandType: CommandType.StoredProcedure
                ).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching documents: {ex.Message}");
            }
        }

        // UPDATE
        public void UpdateDocument(DocumentEntity document)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DocumentId", document.DocumentId);
                parameters.Add("@DocumentName", document.DocumentName);
                parameters.Add("@DocumentPath", document.DocumentPath);

                _db.Execute("SP_Document_Update",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating document: {ex.Message}");
            }
        }

        // DELETE
        public void DeleteDocument(int documentId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DocumentId", documentId);

                _db.Execute("SP_Document_Delete",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting document: {ex.Message}");
            }
        }
    }
}
