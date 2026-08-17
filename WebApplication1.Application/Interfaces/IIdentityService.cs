using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApplication1.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password, int employeeId);
        Task<string?> LoginAsync(string userName, string password);
    }
}

