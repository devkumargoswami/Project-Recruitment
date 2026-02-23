using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListrepositery Listrepositery;

        public ListController(IListrepositery Listsrepositery)
        {
            Listrepositery = Listsrepositery;
        }

        [HttpGet("List")]
        public IActionResult GetAll(int id)
        {
            try
            {
                var data = Listrepositery.GetAllUsers(id);

                if (data == null)
                {
                    return NotFound("No records found.");
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                // Log error here if needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
