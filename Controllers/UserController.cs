using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using Project_Recruitment.DTOs;

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
        [HttpPost("insert")]
        public IActionResult InsertUser([FromBody] UserEntity user)
        {
            if (user == null)
                return BadRequest("User data is required");

            try
            {
                _repository.AddUser(user);
                return Ok(new
                {
                    Status = 1,
                    Message = "User inserted successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = ex.Message
                });
            }
        }

        // =========================
        // UPDATE USER
        // =========================
        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] UserEntity user)
        {
            if (user == null || user.Id <= 0)
                return BadRequest("Valid User Id is required");

            try
            {
                _repository.UpdateUser(user);
                return Ok(new
                {
                    Status = 1,
                    Message = "User updated successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = ex.Message
                });
            }
        }

        // =========================
        // DELETE USER
        // =========================
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id <= 0)
                return BadRequest("Valid User Id is required");

            try
            {
                _repository.DeleteUser(id);
                return Ok(new
                {
                    Status = 1,
                    Message = "User deleted successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = ex.Message
                });
            }
        }

        // =========================
        // GET ALL USERS
        // =========================
        [HttpGet("list")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _repository.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Status = 0,
                    Message = ex.Message
                });
            }
        }

        // =========================
        // LOGIN
        // =========================
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO login)
        {
            if (login == null)
                return BadRequest("Login data is required");

            try
            {
                var user = _repository.Login(login.Email, login.Password);

                if (user == null)
                    return Unauthorized(new
                    {
                        Status = 0,
                        Message = "Invalid email or password"
                    });

                user.Password = null; // security

                return Ok(new
                {
                    Status = 1,
                    Message = "Login successful",
                    Data = user
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Status = 0,
                    Message = ex.Message
                });
            }
        }

        // =========================
        // UPDATE PASSWORD
        // =========================
        [HttpPost("update-password")]
        public IActionResult UpdatePassword([FromBody] UpdatePasswordDTO dto)
        {
            if (dto == null || dto.UserId <= 0)
                return BadRequest("Invalid request");

            try
            {
                _repository.UpdatePassword(dto.UserId, dto.NewPassword, dto.ConfirmPassword);
                return Ok(new
                {
                    Status = 1,
                    Message = "Password updated successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = ex.Message
                });
            }
        }
    }
}