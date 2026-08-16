using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Application.Interfaces;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces;

namespace WebApplication1.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Add(User user)
        {
            bool hasUpper = user.Password.Any(char.IsUpper);
            bool hasSpecial = user.Password.Any(s => !char.IsLetterOrDigit(s));
            bool hasDigit = user.Password.Any(char.IsDigit);

            if (!hasUpper || !hasSpecial || !hasDigit)
            {
                throw new Exception("Password Should Contain At least One Capital Letter,One Special Character Mixed with digits");
            }

            if (!(user.NationalNumber.All(char.IsDigit)))
            {
                throw new Exception("Nationality Number Should Contain Only Digits.");
            }
            
            _userRepository.Add(user);
        }

        public User CheckUserNameAndPassword(string userName, string password)
        {
            var user = _userRepository.GetByUser(userName);

            if (user == null)
            {
                throw new Exception($"{userName} was not found.");
            }

            if (user.Password != password)
            {
                throw new Exception($"Wrong Password.");
            }

            return user;
        }
    }
}
