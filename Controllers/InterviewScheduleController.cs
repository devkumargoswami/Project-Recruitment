using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewScheduleController : ControllerBase
    {
        private readonly IInterviewScheduleRepository _repo;

        public InterviewScheduleController(IInterviewScheduleRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("insert")]
        public IActionResult Insert(InterviewSchedule model)
        {
            _repo.Insert(model);
            return Ok("Interview Scheduled Successfully");
        }

        [HttpPut("update")]
        public IActionResult Update(InterviewSchedule model)
        {
            _repo.Update(model);
            return Ok("Interview Updated Successfully");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok("Interview Deleted Successfully");
        }

        [HttpGet("get/{userId}")]
        public IActionResult Get(int userId)
        {
            return Ok(_repo.GetByUserId(userId));
        }
    }
}
