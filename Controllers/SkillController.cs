using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Business;
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
            skillsRepository.InsertSkill(skill);
            return Ok("Skill Insert Sucessfully");
        }

        // SELECT
        [HttpGet("Select")]
        public IActionResult Select(int? id, int? userId)
        {
            var data = skillsRepository.GetSkill(id, userId);
            return Ok(data);
        }

        // DELETE
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            skillsRepository.DeleteSkill(id);
            return Ok("Skill Deleted Sucessfully");
        }
    }
}
