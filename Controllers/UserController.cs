using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using Project_Recruitment.Entity;

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
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO login)
        {
            try
            {
                var loggedInUser = _repository.Login(login.Email, login.Password);
                if (loggedInUser == null)
                    return Unauthorized("Invalid email or password");

                loggedInUser.Password = null;
                return Ok(loggedInUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Login failed: {ex.Message}");
            }
        }

        [HttpPost("updatePassword")]
        public IActionResult UpdatePassword([FromBody] UpdatePasswordDTO dto)
        {
            try
            {
                _repository.UpdatePassword(dto.UserId, dto.NewPassword, dto.ConfirmPassword);
                return Ok("Password updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

       
