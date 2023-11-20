using BoardApp.Models;
using System.Collections.Generic;

namespace BoardApp.Services.Interfaces
{
    public interface ITestSerializationService
    {
        public List<UserModel> Deserialize();
        public void Serialize(UserModel user);
    }
}
