using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        private readonly IUserRegisterRepository _registerRepository;

        public UserRegisterController(IUserRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserRegisterEntity user)
        {
            try
            {
                if (user == null)
                    return BadRequest(new { Status = false, Message = "Invalid user data" });

                int status = await _registerRepository.RegisterUser(user);

                if (status == 1)
                {
                    return Ok(new
                    {
                        Status = true,
                        Message = "User Registered Successfully"
                    });
                }
                else if (status == 0)
                {
                    return BadRequest(new
                    {
                        Status = false,
                        Message = "Username or Email already exists"
                    });
                }
                else
                {
                    return StatusCode(500, new
                    {
                        Status = false,
                        Message = "Something went wrong"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Status = false,
                    Message = "Internal Server Error",
                    Error = ex.Message
                });
            }
        }
    }
}