using System.Collections.ObjectModel;

namespace BoardApp.Models
{
    public class UserModel : IData
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ObservableCollection<BoardModel> Boards{ get; set; }

        public UserModel(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
