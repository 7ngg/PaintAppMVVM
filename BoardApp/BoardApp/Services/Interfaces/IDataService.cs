using BoardApp.Models;

namespace BoardApp.Services.Interfaces
{
    public interface IDataService
    {
        //public void SendData<T>(T? data) where T : IData;
        public void SendData<TData, TMessage>(TData? data) 
            where TData : IData 
            where TMessage : MyMessageBase<TData>;
    }
}
