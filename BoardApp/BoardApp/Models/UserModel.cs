using System.Collections.Generic;
using Newtonsoft.Json;


namespace BoardApp.Models
{
    public partial class UserModel : IData
    {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Boards")]
        public List<Board> Boards { get; set; }

        public UserModel(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            Boards = new();
        }
    }

    public partial class Board : IData
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Strokes")]
        public string Strokes { get; set; }
    }
}