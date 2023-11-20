using BoardApp.Models;
using BoardApp.Services.Interfaces;

namespace BoardApp.Services.Classes
{
    internal class AuthorizationService : IAuthorizationService
    {
        private readonly ITestSerializationService _testSerializationService;

        public AuthorizationService(ITestSerializationService testSerializationService)
        {
            _testSerializationService = testSerializationService;
        }

        public UserModel SignIn(string username, string password)
        {
            var list = _testSerializationService.Deserialize();

            foreach (var item in list)
            {
                if (item.Username == username && item.Password == password)
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
            var newUser = new UserModel(username, password, email);
            _testSerializationService.Serialize(newUser);
        }
    }
}
