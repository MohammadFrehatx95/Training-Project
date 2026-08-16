using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Application.Interfaces
{
    public interface IUserService
    {
        void Add(User user);
        User CheckUserNameAndPassword(string userName, string password);
    }
}
