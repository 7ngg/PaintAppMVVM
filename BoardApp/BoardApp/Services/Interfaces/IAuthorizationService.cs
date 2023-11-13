namespace BoardApp.Services.Interfaces
{
    public interface IAuthorizationService
    {
        public void SignUp(string username, string password, string email);
        public bool SignIn(string username, string password);
    }
}
