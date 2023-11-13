using BoardApp.Models;
using BoardApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardApp.Services.Classes
{
    internal class AuthorizationService : IAuthorizationService
    {
        private readonly IUserSerializationService _userSerializationService;

        public AuthorizationService(IUserSerializationService userSerializationService)
        {
            _userSerializationService = userSerializationService;
        }

        public bool SignIn(string username, string password)
        {
            var list = _userSerializationService.Deserialize<UserModel>();

            foreach (var item in list)
            {
                if (item.Username == username && item.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public void SignUp(string username, string password, string email)
        {
            var newUser = new UserModel(username, password, email);
            _userSerializationService.Serialize(newUser);
        }
    }
}
