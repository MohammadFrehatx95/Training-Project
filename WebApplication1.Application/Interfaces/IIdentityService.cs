using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Application.Dtos;
using WebApplication1.Application.Dtos.UserDtos;


namespace WebApplication1.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<string?> RegisterAsync(RegisterDto Dto);
        Task<string?> LoginAsync(LoginDto loginDto);
        Task<bool> UnlockAccountAsync(UnlockAccountDto dto);
        Task<int?> GetCurrentEmployeeIdAsync(ClaimsPrincipal user);
    }
}

