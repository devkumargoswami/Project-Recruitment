using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationLevelController : ControllerBase
    {
        private readonly IEducationLevelRepository EducationLevelRepository;

        public EducationLevelController(IEducationLevelRepository educationLevelRepository)
        {
            EducationLevelRepository = educationLevelRepository;
        }

        [HttpPost("Insert")]
        public IActionResult Insert(EducationLevelEntity entity)
        {
            try
            {
                var result = EducationLevelRepository.Insert(entity);

                if (result == 1)
                    return Ok("Education Level Inserted successfully");

                return BadRequest("Education Level already exists");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error inserting education level: {ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = EducationLevelRepository.GetById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching education level: {ex.Message}");
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(EducationLevelEntity entity)
        {
            try
            {
                var result = EducationLevelRepository.Update(entity);

                if (result > 0)
                    return Ok("Education Level Updated successfully");

                return BadRequest("Education level Update failed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating education level: {ex.Message}");
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = EducationLevelRepository.Delete(id);

                if (result > 0)
                    return Ok("Education Level Deleted successfully");

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting education level: {ex.Message}");
            }
        }
    }
}
