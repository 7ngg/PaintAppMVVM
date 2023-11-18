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

        public void SendData<T>(T? data) where T : IData
        {
            if (data != null)
            {
                _messenger.Send(new UserDataMessage() { UserData = data });
            }
            else
            {
                throw new ArgumentNullException(nameof(data));
            }
        }
    }
}
