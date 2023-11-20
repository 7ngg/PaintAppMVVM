using BoardApp.Models;
using BoardApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BoardApp.Services.Classes
{
    internal class TestSerializationService : ITestSerializationService
    {
        private readonly IUserSerializationService _userSerializationService;
        private readonly IBoardSerializationService _boardSerializationService;
        private readonly string _baseDirectory;
        private readonly string _fileName = "userData.json";

        public TestSerializationService(IUserSerializationService userSerializationService, IBoardSerializationService boardSerializationService)
        {
            _userSerializationService = userSerializationService;
            _boardSerializationService = boardSerializationService;
            _baseDirectory = Directory.GetCurrentDirectory();
        }

        public List<UserModel> Deserialize()
        {

            var tmpUserList = _userSerializationService.Deserialize<UserModel>();

            foreach (var user in tmpUserList)
            {
                var targetDirectory = Path.Combine(_baseDirectory, "boards", user.Username);

                if (Directory.Exists(targetDirectory))
                {
                    var files = Directory.GetFiles(targetDirectory);

                    if (files.Length != 0)
                    {
                        foreach (var file in files)
                        {
                            user.Boards.Add(_boardSerializationService.Deserialize(file));
                        }
                    }
                }
            }

            return tmpUserList;


            //using FileStream stream = new(_fileName, FileMode.OpenOrCreate);
            //using StreamReader reader = new(stream);

            //string json = reader.ReadToEnd();
            //return JsonConvert.DeserializeObject<List<UserModel>>(json);
        }

        public void Serialize(UserModel user)
        {

            var tmpList = Deserialize();
            tmpList.Add(user);

            _userSerializationService.Serialize(tmpList);

            foreach (var item in tmpList)
            {
                var targetDirectory = Path.Combine(_baseDirectory, "boards", item.Username);
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                if (item.Boards != null)
                {
                    foreach (var board in item.Boards)
                    {
                        _boardSerializationService.Serialize(board, targetDirectory);
                    }
                }
            }


            //var tmpList = Deserialize();

            //if (tmpList == null)
            //{
            //    tmpList = new();
            //}

            //tmpList.Add(user);

            //using FileStream stream = new(_fileName, FileMode.OpenOrCreate);
            //using StreamWriter writer = new(stream);

            //string json = JsonConvert.SerializeObject(tmpList, Formatting.Indented);
            //writer.Write(json);
        }
    }
}
