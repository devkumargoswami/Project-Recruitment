using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.DTOs;
using Project_Recruitment.Interface;
using System.Text.Json;

namespace Project_Recruitment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserrepositery _repository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserrepositery repository, ILogger<UserController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // =========================
        // INSERT USER
        // =========================
        [HttpPost("insert")]
        public IActionResult InsertUser([FromBody] UserEntity user)
        {
            if (user == null)
                return BadRequest(new
                {
                    Status = 0,
                    Message = "User data is required"
                });

            try
            {
                _repository.AddUser(user);

                return Ok(new
                {
                    Status = 1,
                    Message = "User added successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddUser Error: {ex.Message}");
                return BadRequest(new
                {
                    Status = 0,
                    Message = ex.Message
                });
            }
        }

        // =========================
        // UPDATE USER ✅ FIXED
        // =========================
        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] UserEntity user)
        {
            // ===== LOGGING =====
            _logger.LogInformation($"UpdateUser called with ID: {user?.Id}");
            _logger.LogInformation($"Request body: {JsonSerializer.Serialize(user)}");

            // ===== VALIDATION =====
            if (user == null)
            {
                _logger.LogWarning("UpdateUser: User object is null");
                return BadRequest(new
                {
                    Status = 0,
                    Message = "User data is required"
                });
            }

            if (user.Id <= 0)
            {
                _logger.LogWarning($"UpdateUser: Invalid user ID: {user.Id}");
                return BadRequest(new
                {
                    Status = 0,
                    Message = "Valid User Id is required"
                });
            }

            try
            {
                _logger.LogInformation($"Calling repository.UpdateUser() for ID: {user.Id}");

                _repository.UpdateUser(user);

                _logger.LogInformation($"User {user.Id} updated successfully");

                return Ok(new
                {
                    Status = 1,
                    Message = "User updated successfully",
                    Data = user
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateUser Error: {ex.Message}");
                _logger.LogError($"Stack Trace: {ex.StackTrace}");

                return StatusCode(500, new
                {
                    Status = 0,
                    Message = $"Update failed: {ex.Message}",
                    Error = ex.Message
                });
            }
        }

        // =========================
        // DELETE USER
        // =========================
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _logger.LogInformation($"DeleteUser called with ID: {id}");

            if (id <= 0)
                return BadRequest(new
                {
                    Status = 0,
                    Message = "Valid User Id is required"
                });

            try
            {
                _repository.DeleteUser(id);

                _logger.LogInformation($"User {id} deleted successfully");

                return Ok(new
                {
                    Status = 1,
                    Message = "User deleted successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteUser Error: {ex.Message}");

                return StatusCode(500, new
                {
                    Status = 0,
                    Message = $"Delete failed: {ex.Message}"
                });
            }
        }

        // =========================
        // GET ALL USERS
        // =========================
        [HttpGet("list")]
        public IActionResult GetUsers()
        {
            _logger.LogInformation("GetUsers called");

            try
            {
                var users = _repository.GetUsers();

                if (users == null)
                    return Ok(new List<UserEntity>());

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetUsers Error: {ex.Message}");

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
                return BadRequest(new
                {
                    Status = 0,
                    Message = "Login data is required"
                });

            try
            {
                var loginUser = _repository.Login(login.Email, login.Password);

                if (loginUser == null)
                    return Unauthorized(new
                    {
                        Status = 0,
                        Message = "Invalid email or password"
                    });

                loginUser.Password = null; // hide password

                return Ok(new
                {
                    success = true,
                    user = loginUser
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login Error: {ex.Message}");

                return StatusCode(500, new
                {
                    success = false,
                    message = "Login failed",
                    error = ex.Message
                });
            }
        }

        // =========================
        // UPDATE PASSWORD
        // =========================
        [HttpPost("update-password")]
        public IActionResult UpdatePassword([FromBody] UpdatePasswordDTO dto)
        {
            if (dto == null || (dto.UserId == null && string.IsNullOrEmpty(dto.Email)))
            {
                return BadRequest(new
                {
                    success = false,
                    message = "UserId or Email is required"
                });
            }

            try
            {
                _repository.UpdatePassword(dto.UserId, dto.Email, dto.NewPassword, dto.ConfirmPassword);

                return Ok(new
                {
                    success = true,
                    message = "Password updated successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdatePassword Error: {ex.Message}");

                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}