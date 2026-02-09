using Microsoft.AspNetCore.Mvc;

namespace Project_Recruitment.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserrepositery _repository;

        public UserController(IUserrepositery repository)
        {
            _repository = repository;
        }

        [HttpPost("addUser")]
        public IActionResult AddUser(UserEntity user)
        {
            _repository.AddUser(user);
            return Ok("User added successfully");
        }

        [HttpGet("getUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_repository.GetUsers());
        }
    }
}

