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

        [HttpPost("insert")]
        public async Task<IActionResult> Insert(ExperienceDTO dto)
        {
            try
            {
               experience.InsertExperience(dto);
               return Ok("Experience inserted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error inserting experience",
                    error = ex.Message
                });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ExperienceUpdateDTO dto)
        {
            try
            {
                experience.UpdateExperience(dto);
                return Ok("Updated SuccessFully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error updating experience",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
             experience.DeleteExperience(id);
                return Ok("Deleted SuccessFully");  
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error deleting experience",
                    error = ex.Message
                });
            }
        }

        [HttpGet("get/{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                    var result = await experience.GetExperienceByUser(userId);
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error fetching experience",
                    error = ex.Message
                });
            }
        }
    }
}
