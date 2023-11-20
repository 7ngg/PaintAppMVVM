using BoardApp.Messages;
using BoardApp.Models;
using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace BoardApp.Services.Classes
{
    class DataService : IDataService
    {
        private readonly IMessenger _messenger;

        public DataService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void SendData<TData, TMessage>(TData? data) 
            where TData : IData 
            where TMessage : MyMessageBase<TData>
        {
            if (data != null)
            {
                var message = (TMessage)Activator.CreateInstance(typeof(TMessage), data);
                _messenger.Send(message);
            }
            else
            {
                throw new ArgumentNullException(nameof(data));
            }
        }
    }
}
