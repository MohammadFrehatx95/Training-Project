using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebApplication1.Application.Dtos.UserDtos;
using WebApplication1.Application.Interfaces;
using WebApplication1.Domain.Entities;


namespace WebApplication1.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtService _jwtService;

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<string> RegisterAsync(RegisterDto Dto)
        {
            var user = new ApplicationUser
            {
                FirstName = Dto.FirstName,
                LastName = Dto.LastName,
                UserName = Dto.UserName,
                Email = Dto.Email,
                NationalNumber = Dto.NationalNumber,
                DateOfBirth = Dto.DateOfBirth,
                EmployeeId = Dto.EmployeeId,
                LockoutEnabled = true
            };

            var result = await _userManager.CreateAsync(user, Dto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"{error.Code}: {error.Description}");
                }

                return null;
            }

            await _userManager.AddToRoleAsync(user, Dto.Role);

            return await _jwtService.GenerateToken(user);
        }

        //public async Task<bool> LoginAsync(string userName, string password)
        //{
        //    var user = await _userManager.FindByNameAsync(userName);

        //    if (user == null)
        //        return false;

        //    return await _userManager.CheckPasswordAsync(user, password);
        //}

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, true);

            if (result.IsLockedOut)
                return "LOCKED";

            if (!result.Succeeded)
                return null;

            var user = await _userManager.FindByNameAsync(dto.UserName);

            if (user == null)
                return null;

            return await _jwtService.GenerateToken(user);
        }

        public async Task<bool> UnlockAccountAsync(UnlockAccountDto dto)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.NationalNumber == dto.NationalNumber);

            if (user == null)
                return false;

            if (user.DateOfBirth.Date != dto.DateOfBirth.Date)
                return false;

            var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!passwordValid)
                return false;

            await _userManager.SetLockoutEndDateAsync(user, null);
            await _userManager.ResetAccessFailedCountAsync(user);

            return true;
        }

        public async Task<int?> GetCurrentEmployeeIdAsync(ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return null;

            var applicationUser = await _userManager.FindByIdAsync(userId);

            if (applicationUser == null)
                return null;

            return applicationUser.EmployeeId;
        }
    }
}