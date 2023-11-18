using BoardApp.Models;
using BoardApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
                users = JsonSerializer.Deserialize<List<T>>(json) ?? throw new ArgumentNullException(nameof(json));
            }

            return users;
        }

        public void Serialize<T>(T user)
        {
            var tmpList = Deserialize<T>();
            using FileStream stream = new(_fileName, FileMode.OpenOrCreate);
            using StreamWriter writer = new(stream);

            tmpList.Add(user);
            string json = JsonSerializer.Serialize(tmpList);
            writer.Write(json);
        }
    }
}
