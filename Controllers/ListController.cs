using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListrepositery Lists;

        public ListController(IListrepositery List)
        {
            Lists = List;
        }

        [HttpGet("List")]
        public IActionResult GetAll(int id)
        {
            var data = Lists.GetAllUsers(id);
            return Ok(data);
        }
    }
}
