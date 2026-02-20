using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEducationController : ControllerBase
    {
        private readonly IUserEducationRepository Educationrepository;

        public UserEducationController(IUserEducationRepository EducatioRepository)
        {
            Educationrepository = EducatioRepository;
        }

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] UserEducationEntity education)
        {
            try
            {
                Educationrepository.Insert(education);
                return Ok("Education inserted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByUser/{userId}")]
        public IActionResult Get(int userId)
        {
            try
            {
                var data = Educationrepository.Get(userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UserEducationEntity education)
        {
            try
            {
                int rows = Educationrepository.Update(education);

                if (rows > 0)
                    return Ok("Education updated successfully");

                return NotFound("Education not found or duplicate exists.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Educationrepository.Delete(id);
                return Ok("Education deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
