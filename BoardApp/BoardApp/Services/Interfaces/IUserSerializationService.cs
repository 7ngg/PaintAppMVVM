using System.Collections.Generic;

namespace BoardApp.Services.Interfaces
{
    public interface IUserSerializationService
    {
        public List<T> Deserialize<T>();
        public void Serialize<T>(T user);
    }
}
