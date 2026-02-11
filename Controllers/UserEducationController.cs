using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEducationController : ControllerBase
    {
        private readonly IUserEducationRepository _repository;

        public UserEducationController(IUserEducationRepository repository)
        {
            _repository = repository;
        }

        // INSERT
        [HttpPost("insert")]
        public IActionResult InsertEducation([FromBody] UserEducationEntity education)
        {
            try
            {
                _repository.InsertEducation(education);
                return Ok("Education inserted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // SELECT
        [HttpGet("getByUser/{userId}")]
        public IActionResult GetByUser(int userId)
        {
            try
            {
                var data = _repository.GetEducationByUserId(userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // UPDATE
        [HttpPut("update")]
        public IActionResult UpdateEducation([FromBody] UserEducationEntity education)
        {
            try
            {
                int rows = _repository.UpdateEducation(education);

                if (rows > 0)
                    return Ok("Education updated successfully");

                return NotFound("Education not found or duplicate exists.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEducation(int id)
        {
            try
            {
                _repository.DeleteEducation(id);
                return Ok("Education deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
