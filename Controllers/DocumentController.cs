using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

[ApiController]
[Route("api/[controller]")]
public class DocumentController : ControllerBase
{
    private readonly IDocumentRepository documentRepository;

    public DocumentController(IDocumentRepository documentsRepository)
    {
        documentRepository = documentsRepository;
    }

    [HttpPost("insert")]
    public IActionResult Insert(DocumentEntity model)
    {
        try
        {
            documentRepository.InsertDocument(model);
            return Ok("Document inserted successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error inserting document: {ex.Message}");
        }
    }

    [HttpGet("getByUser/{userId}")]
    public IActionResult GetByUserId(int userId)
    {
        try
        {
            var data = documentRepository.GetDocumentsByUserId(userId);

            if (data == null || !data.Any())
                return NotFound("No documents found");

            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error fetching documents: {ex.Message}");
        }
    }

    [HttpPut("update")]
    public IActionResult Update(DocumentEntity model)
    {
        try
        {
            documentRepository.UpdateDocument(model);
            return Ok("Document updated successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error updating document: {ex.Message}");
        }
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            documentRepository.DeleteDocument(id);
            return Ok("Document deleted successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error deleting document: {ex.Message}");
        }
    }
}
