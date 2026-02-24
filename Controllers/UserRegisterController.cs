using Microsoft.AspNetCore.Mvc;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;

namespace Project_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        private readonly IRegisterRepository RegistersRepository;

        public UserRegisterController(IRegisterRepository RegisterRepository)
        {
            RegistersRepository = RegisterRepository;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(UserEntity user)
        {
            try
            {
                if (user == null)
                    return BadRequest(new { Message = "Invalid user data" });

                var status = RegistersRepository.RegisterUser(user);

                if (status == 1)
                {
                    return Ok(new
                    {
                        Status = true,
                        Message = "User Registered Successfully"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Status = false,
                        Message = "Username or Email already exists"
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
