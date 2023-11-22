using BoardApp.Models;
using System.Collections.Generic;

namespace BoardApp.Services.Interfaces
{
    public interface ISerializationService
    {
        public List<T> Deserialize<T>() where T : UserModel;
        public void Serialize<T>(T user) where T : UserModel;
    }
}
