using BoardApp.Models;
using BoardApp.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BoardApp.Services.Classes
{
    internal class UserSerializationService : IUserSerializationService
    {
        private readonly string _fileName = "userData.json";

        public List<T> Deserialize<T>() where T : UserModel
        {
            using FileStream stream = new(_fileName, FileMode.OpenOrCreate);
            using StreamReader reader = new(stream);

            string json = reader.ReadToEnd();
            List<T>? users = JsonSerializer.Deserialize<List<T>>(json) ?? new();

            return users;
        }

        public void Serialize<T>(T user) where T : UserModel
        {
            using FileStream stream = new(_fileName, FileMode.Append);
            using StreamWriter writer = new(stream);

            var tmpList = new List<T>() { user };
            string json = JsonSerializer.Serialize(tmpList);
            writer.Write(json);
        }
    }
}
