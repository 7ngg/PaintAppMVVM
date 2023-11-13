using BoardApp.Messages;
using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace BoardApp.Services.Classes
{
    public class UserDialogService : IUserDialogService
    {
        //private Window? _mainWindow;
        //private readonly IMessenger _messenger;

        //public UserDialogService(IMessenger messenger)
        //{
        //    _messenger = messenger;
        //}

        public void OpenWindow<T>() where T : Window, new()
        {
            //if (_mainWindow is { } window)
            //{
            //    window.Show();
            //    return;
            //}

            //window = new BoardView();
            //_mainWindow = window;
            //window.Show();

            Window window = new T();
            window.Show();
        }
    }
}
