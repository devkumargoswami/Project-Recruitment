using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.DTOs;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperience experience;

        public ExperienceController(IExperience experience)
        {
            this.experience = experience;
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] ExperienceDTO dto)
        {
            try
            {
                experience.InsertExperience(dto);
                return Ok(new { status = 200, message = "Experience inserted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = 500, message = "Error inserting experience", error = ex.Message });
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ExperienceUpdateDTO dto)
        {
            try
            {
                experience.UpdateExperience(dto);
                return Ok(new { status = 200, message = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = 500, message = "Error updating experience", error = ex.Message });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                experience.DeleteExperience(id);
                return Ok(new { status = 200, message = "Deleted Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = 500, message = "Error deleting experience", error = ex.Message });
            }
        }

        [HttpGet("Select")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await experience.GetExperienceByUser(0);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = 500, message = "Error fetching experience", error = ex.Message });
            }
        }

        [HttpGet("Select/{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                var result = await experience.GetExperienceByUser(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = 500, message = "Error fetching experience", error = ex.Message });
            }
        }
    }
}