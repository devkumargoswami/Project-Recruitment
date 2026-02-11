using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserrepositery _repository;

        public UserController(IUserrepositery repository)
        {
            _repository = repository;
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
