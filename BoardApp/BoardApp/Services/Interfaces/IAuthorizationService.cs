using BoardApp.Models;

namespace BoardApp.Services.Interfaces
{
    public interface IAuthorizationService
    {
        public void SignUp(string username, string password, string email);
        public UserModel SignIn(string username, string password);
    }
}
