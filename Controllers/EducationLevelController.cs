using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationLevelController : ControllerBase
    {
        private readonly IEducationLevelRepository _repository;

        public EducationLevelController(IEducationLevelRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Insert(EducationLevelEntity entity)
        {
            var result = _repository.Insert(entity);

            if (result == 1)
                return Ok("Inserted successfully");

            return BadRequest("Education Level already exists");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _repository.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(EducationLevelEntity entity)
        {
            var result = _repository.Update(entity);

            if (result > 0)
                return Ok("Updated successfully");

            return BadRequest("Update failed");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);

            if (result > 0)
                return Ok("Deleted successfully");

            return NotFound();
        }
    }
}
