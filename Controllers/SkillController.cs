using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepository skillsRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            skillsRepository = skillRepository;
        }

        // INSERT
        [HttpPost("Insert")]
        public IActionResult Insert(Skill skill)
        {
            try
            {
                skillsRepository.InsertSkill(skill);
                return Ok("Skill Inserted Successfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error while inserting skill.");
            }
        }

        // SELECT
        [HttpGet("Select")]
        public IActionResult Select(int? id, int? userId)
        {
            try
            {
                var data = skillsRepository.GetSkill(id, userId);

                if (data == null)
                    return NotFound("Skill not found.");

                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error while fetching skill.");
            }
        }

        // DELETE
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                skillsRepository.DeleteSkill(id);
                return Ok("Skill Deleted Successfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error while deleting skill.");
            }
        }
    }
}
