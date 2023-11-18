using BoardApp.Models;

namespace BoardApp.Services.Interfaces
{
    interface IDataService
    {
        public void SendData<T>(T data) where T : IData;
    }
}
