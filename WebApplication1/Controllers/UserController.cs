using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Dtos.UserDtos;
using WebApplication1.Application.Interfaces;
using WebApplication1.Domain.Entities;
using WebApplication1.Infrastructure.Data;

namespace app_homework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser([FromBody] RegisterDto regDto)
        {
            try
            {
                var user = new User()
                {
                    FirstName = regDto.FirstName,
                    LastName = regDto.LastName,
                    DateOfBirth = regDto.DateOfBirth,
                    Nationality = regDto.Nationality,
                    Email = regDto.Email,
                    UserName = regDto.UserName,
                    Password = regDto.Password,
                    Gender = regDto.Gender,
                    NationalNumber = regDto.NationalNumber,
                    EmployeeId = regDto.EmployeeId,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                };

                _userService.Add(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("LoginUser")]
        public IActionResult LoginUser(string username, string password)
        {
            try
            {
                var user = _userService.CheckUserNameAndPassword(username, password);
                return Ok("User Login Successfully!.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
