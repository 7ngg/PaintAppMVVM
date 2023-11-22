using BoardApp.Services.Interfaces;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using BoardApp.Models;
using System;

namespace BoardApp.Services.Classes
{
    public class SerializationService : ISerializationService
    {
        private readonly string _defaultFileName = "userData.json";

        public List<T> Deserialize<T>() where T : UserModel
        {
            if (!File.Exists(_defaultFileName))
            {
                File.Create(_defaultFileName).Close();
            }

            string json = File.ReadAllText(_defaultFileName);
            var deserializedObj = JsonConvert.DeserializeObject<List<T>>(json);
            return deserializedObj;
        }

        public void Serialize<T>(T user) where T : UserModel
        {
            var tmpList = Deserialize<T>() ?? new List<T>();
            bool userExists = false;
            
            foreach (var item in tmpList)
            {
                if (item.Username == user.Username)
                {
                    item.Username = user.Username;
                    item.Password = user.Password;
                    item.Email = user.Email;
                    item.Boards = user.Boards;
                    userExists = true;
                }
            }

            if (!userExists)
            {
                tmpList.Add(user);
            }

            string json = JsonConvert.SerializeObject(tmpList, Formatting.Indented);
            using StreamWriter writer = new(_defaultFileName, false);
            writer.Write(json);
        }
    }
}
