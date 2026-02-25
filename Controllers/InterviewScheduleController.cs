using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewScheduleController : ControllerBase
    {
        private readonly IInterviewScheduleRepository InterviewScheduleRepository;

        public InterviewScheduleController(IInterviewScheduleRepository interviewScheduleRepository)
        {
            InterviewScheduleRepository = interviewScheduleRepository;
        }

        [HttpPost("insert")]
        public IActionResult Insert(InterviewSchedule model)
        {
            try
            {
                InterviewScheduleRepository.Insert(model);
                return Ok("Interview Scheduled Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("update")]
        public IActionResult Update(InterviewSchedule model)
        {
            try
            {
                InterviewScheduleRepository.Update(model);
                return Ok("Interview Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                InterviewScheduleRepository.Delete(id);
                return Ok("Interview Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("get/{userId}")]
        public IActionResult Get(int userId)
        {
            try
            {
                var result = InterviewScheduleRepository.GetByUserId(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}