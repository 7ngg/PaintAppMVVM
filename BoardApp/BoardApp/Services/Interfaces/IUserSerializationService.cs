using BoardApp.Models;
using System.Collections.Generic;

namespace BoardApp.Services.Interfaces
{
    internal interface IUserSerializationService
    {
        public List<T> Deserialize<T>() where T : UserModel;
        public void Serialize<T>(T users) where T : UserModel;
    }
}
