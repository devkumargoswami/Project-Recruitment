using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IUserrepositery _user;

        public ListController(IUserrepositery user)
        {
            _user = user;
        }

        [HttpGet("List")]
        public IActionResult GetAll()
        {
            var data = _user.GetAllUsers();
            return Ok(data);
        }
    }
}
