using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Dtos.UserDtos;
using WebApplication1.Application.Interfaces;

namespace app_homework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _identityService.RegisterAsync(dto.FirstName, dto.LastName, dto.UserName, dto.Email, dto.Password, dto.EmployeeId);

            if (!result)
                return BadRequest("Registration failed.");

            return Ok("User registered successfully.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _identityService.LoginAsync(dto.UserName,dto.Password);

            if (token == null)
            {
                return BadRequest("Invalid username or password.");
            }

            return Ok(token);
        }
    }
   
}