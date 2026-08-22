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
            var result = await _identityService.RegisterAsync(dto);

            if (result == null)
                return BadRequest("Registration failed.");

            return Ok("User registered successfully.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _identityService.LoginAsync(dto);

            if (token == "LOCKED")
                return BadRequest("Your account is locked.");

            if (token == null)
                return BadRequest("Invalid username or password.");

            return Ok(token);
        }

        [HttpPost("unlock")]
        public async Task<IActionResult> Unlock(UnlockAccountDto dto)
        {
            var result = await _identityService.UnlockAccountAsync(dto);

            if (!result)
            {
                return BadRequest("Invalid National Number, Date of Birth or Password.");
            }

            return Ok("Account unlocked successfully.");
        }
    }
   
}