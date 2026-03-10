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

    [HttpPost("Insert")]
    public IActionResult Insert(DocumentEntity model)
    {
        try
        {
            documentRepository.Insert(model);
            return Ok(new { message = "Document Inserted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error inserting document: {ex.Message}");
        }
    }

    [HttpGet("GetByUser/{userId}")]
    public IActionResult Get(int userId)
    {
        try
        {
            var data = documentRepository.Get(userId);

            if (data == null || !data.Any())
                return NotFound("No documents found");

            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error fetching documents: {ex.Message}");
        }
    }

    [HttpPut("Update")]
    public IActionResult Update(DocumentEntity model)
    {
        try
        {
            documentRepository.Update(model);
            return Ok(new { message = "Document Updated successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error updating document: {ex.Message}");
        }
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            documentRepository.Delete(id);
            return Ok(new { message = "Document Deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error deleting document: {ex.Message}");
        }
    }
}
