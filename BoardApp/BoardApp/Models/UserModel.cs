using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BoardApp.Models
{
    public class UserModel : IData
    {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        public ObservableCollection<BoardModel> Boards{ get; set; }

        public UserModel()
        {
            Boards = new();
        }

        public UserModel(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            Boards = new();
        }
    }
}
