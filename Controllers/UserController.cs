using Microsoft.AspNetCore.Mvc;

namespace Project_Recruitment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserrepositery _repository;

        public UserController(IUserrepositery repository)
        {
            _repository = repository;
        }

        // =========================
        // INSERT USER
        // =========================
        [HttpPost("addUser")]
        public IActionResult AddUser([FromBody] UserEntity user)
        {
            try
            {
                _repository.AddUser(user);
                return Ok(new { message = "User inserted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // =========================
        // UPDATE USER
        // =========================
        [HttpPut("updateUser")]
        public IActionResult UpdateUser([FromBody] UserEntity user)
        {
            try
            {
                _repository.UpdateUser(user);
                return Ok(new { message = "User updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // =========================
        // DELETE USER
        // =========================
        [HttpDelete("deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _repository.DeleteUser(id);
                return Ok(new { message = "User deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // =========================
        // GET USERS
        // =========================
        [HttpGet("getUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _repository.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
