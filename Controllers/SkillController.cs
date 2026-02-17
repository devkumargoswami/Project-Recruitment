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
        private readonly SkillController;

        public SkillController(SkillController)
        {
            _service = service;
        }

        // INSERT
        [HttpPost("Insert")]
        public IActionResult Insert(Skill skill)
        {
            var result = _service.InsertSkill(skill);
            return Ok(result);
        }

        // SELECT
        [HttpGet("Select")]
        public IActionResult Select(int? id, int? userId)
        {
            var data = _service.GetSkill(id, userId);
            return Ok(data);
        }

        // DELETE
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteSkill(id);
            return Ok("Deleted Successfully");
        }
    }
}
