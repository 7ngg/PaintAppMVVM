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

        [JsonIgnore]
        public ObservableCollection<BoardModel> Boards{ get; set; }

        [JsonConstructor]
        public UserModel(string username, string password, string email, ObservableCollection<BoardModel> boards = null)
        {
            Username = username;
            Password = password;
            Email = email;
            Boards = (boards == null) ? new() : boards;
        }
    }
}
