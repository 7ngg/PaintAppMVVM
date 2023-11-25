using BoardApp.Models;
using BoardApp.Services.Interfaces;

namespace BoardApp.Services.Classes
{
    internal class AuthorizationService : IAuthorizationService
    {
        private readonly ISerializationService _serializationService;

        public AuthorizationService(ISerializationService serializationService)
        {
            _serializationService = serializationService;
        }

        public UserModel SignIn(string username, string password)
        {
            var list = _serializationService.Deserialize<UserModel>();
            
            foreach (var item in list)
            {
                if (item.Username == username && BCrypt.Net.BCrypt.EnhancedVerify(password, item.Password))
                {
                    return new UserModel(item.Username, item.Password, item.Email)
                    {
                        Boards = item.Boards
                    };
                }
            }

            return null;
        }

        public void SignUp(string username, string password, string email)
        {
            var newUser = new UserModel(username, BCrypt.Net.BCrypt.EnhancedHashPassword(password), email);
            _serializationService.Serialize(newUser);
        }
    }
}
