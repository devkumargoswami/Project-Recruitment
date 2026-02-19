using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Interface;
using Project_Recruitment.DTOs;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly Interface.IResultRepositry _result;

        public ResultController(Interface.IResultRepositry result)
        {
            _result = result;
        }

        [HttpPost("Insert")]
        public IActionResult Insert(ResultDTO model)
        {
            return Ok(_result.Insert(model));
        }

        [HttpPut("Update")]
        public IActionResult Update(ResultDTO model)
        {
            return Ok(_result.Update(model));
        }

        [HttpGet("GetByCandidate/{id}")]
        public IActionResult GetByCandidate(int id)
        {
            return Ok(_result.GetByCandidate(id));
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_result.Delete(id));
        }
    }
}
