using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

[ApiController]
[Route("api/[controller]")]
public class DocumentController : ControllerBase
{
    private readonly IDocumentRepository _documentRepository;

    public DocumentController(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    [HttpPost("insert")]
    public IActionResult Insert(DocumentEntity model)
    {
        _documentRepository.InsertDocument(model);
        return Ok("Document inserted successfully");
    }

    [HttpGet("getByUser/{userId}")]
    public IActionResult GetByUserId(int userId)
    {
        var data = _documentRepository.GetDocumentsByUserId(userId);
        return Ok(data);
    }

    [HttpPut("update")]
    public IActionResult Update(DocumentEntity model)
    {
        _documentRepository.UpdateDocument(model);
        return Ok("Document updated successfully");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        _documentRepository.DeleteDocument(id);
        return Ok("Document deleted successfully");
    }
}
