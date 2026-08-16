using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetByUser(string userName);
    }
}
