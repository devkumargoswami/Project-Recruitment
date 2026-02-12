using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.DTOs;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperience _experience;

        public ExperienceController(IExperience experience)
        {
            _experience = experience;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert(ExperienceDTO dto)
        {
            return Ok(await _experience.InsertExperience(dto));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ExperienceUpdateDTO dto)
        {
            return Ok(await _experience.UpdateExperience(dto));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _experience.DeleteExperience(id));
        }

        [HttpGet("get/{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            return Ok(await _experience.GetExperienceByUser(userId));
        }
    }
}
