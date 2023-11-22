using BoardApp.Services.Interfaces;
using BoardApp.ViewModels;
using BoardApp.Views;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Reflection;
using System.Windows;

namespace BoardApp.Services.Classes
{
    public class UserDialogService : IUserDialogService
    {
        //private readonly IMessenger _messenger;
        //private IServiceProvider _services;

        //public UserDialogService(IMessenger messenger)
        //{
        //    _messenger = messenger;
        //}

        //public void OpenWindow<T>() where T : Window, new()
        //{
        //    //if (_mainWindow is { } window)
        //    //{
        //    //    window.Show();
        //    //    return;
        //    //}


        //    //window = new ;
        //    //_mainWindow = window;
        //    //window.Show();

        //    if (_currentWindow is { } window)
        //    {
        //        window.Show();
        //        return;
        //    }

        //    window = App.Container.GetInstance<T>();
        //    _currentWindow = window;
        //    window.Show();
        //}

        //public void OpenWindow<T>() where T : Window, new()
        //{
        //    var window = new T()
        //    {
        //        DataContext = App.Container.GetInstance<T>()
        //    };
        //    window.ShowDialog();

        //    //if (_currentWindow != null)
        //    //{
        //    //    _currentWindow.Activate();
        //    //    return;
        //    //}

        //    //T newWindow = new()
        //    //{
        //    //    DataContext = App.Container.GetInstance<T>()
        //    //};
        //    //_currentWindow?.Close();

        //    //_currentWindow = newWindow;
        //    //_currentWindow.Closed += (sender, e) => _currentWindow = null;
        //    //_currentWindow.Show();
        //}

        private Window _current;
        public void OpenWindow<T>() where T : Window, new()
        {
            if (_current is { } window)
            {
                window.Show();
            }

            window = App.Container.GetInstance<T>();
            window.Closed += (_, _) => _current = null;
            _current = window;
            window.ShowDialog();
        }
    }
}
