using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Models;
using Project_Recruitment.Repository;

namespace Project_Recruitment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserrepositery _repository;

        public UserController(IUserrepositery repository)
        {
            _repository = repository;
        }

    
        [HttpPost("addUser")]
        public IActionResult AddUser([FromBody] UserEntity user)
        {
            _repository.AddUser(user);
            return Ok("User added successfully");
        }

  
        [HttpGet("getUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_repository.GetUsers());
        }

        [HttpPut("updateUser")]
        public IActionResult UpdateUser([FromBody] UserEntity user)
        {
            _repository.UpdateUser(user);
            return Ok("User updated successfully");
        }

        
        [HttpDelete("deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _repository.DeleteUser(id);
            return Ok("User deleted successfully");
        }
    }
}
