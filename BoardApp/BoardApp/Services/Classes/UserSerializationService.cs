using BoardApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BoardApp.Services.Classes
{
    public class UserSerializationService : IUserSerializationService
    {
        private readonly string _fileName = "userData.json";

        public List<T> Deserialize<T>()
        {
            List<T> users = new();
            var fileInfo = new FileInfo(_fileName);

            if (fileInfo.Exists && fileInfo.Length != 0)
            {
                using FileStream stream = new(_fileName, FileMode.OpenOrCreate);
                using StreamReader reader = new(stream);
                string json = reader.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<T>>(json) ?? throw new ArgumentNullException(nameof(json));
            }

            return users;
        }

        public void Serialize<T>(List<T> users)
        {
            using FileStream stream = new(_fileName, FileMode.OpenOrCreate);
            using StreamWriter writer = new(stream);

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            writer.Write(json);
        }
    }
}
