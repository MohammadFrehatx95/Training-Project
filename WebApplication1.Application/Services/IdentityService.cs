using Microsoft.AspNetCore.Identity;
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

        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password, int employeeId)
        {
            var user = new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Email = email,
                EmployeeId = employeeId
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"{error.Code}: {error.Description}");
                }

                return false;
            }

            return true;
        }

        //public async Task<bool> LoginAsync(string userName, string password)
        //{
        //    var user = await _userManager.FindByNameAsync(userName);

        //    if (user == null)
        //        return false;

        //    return await _userManager.CheckPasswordAsync(user, password);
        //}

        public async Task<string?> LoginAsync(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, true);

            if (!result.Succeeded)
                return null;

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
                return null;

            return _jwtService.GenerateToken(user);
        }
    }
}