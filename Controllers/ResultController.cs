    using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Interface;
using Project_Recruitment.DTOs;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepositry ResultRepositry;

        public ResultController(IResultRepositry result)
        {
            ResultRepositry = result;
        }

        [HttpPost("Insert")]
        public IActionResult Insert(ResultDTO model)
        {
            try
            {
                var data = ResultRepositry.Insert(model);
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error while inserting result.");
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(ResultDTO model)
        {
            try
            {
                var data = ResultRepositry.Update(model);
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error while updating result.");
            }
        }

        [HttpGet("GetByCandidate/{id}")]
        public IActionResult GetByCandidate(int id)
        {
            try
            {
                var data = ResultRepositry.GetByCandidate(id);

                if (data == null)
                    return NotFound("Candidate result not found.");

                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error while fetching result.");
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = ResultRepositry.Delete(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error while deleting result.");
            }
        }
    }
}
