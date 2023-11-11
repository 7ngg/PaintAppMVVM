﻿using BoardApp.Services.Classes;
using BoardApp.Services.Interfaces;
using BoardApp.ViewModels;
using BoardApp.Views;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using System.Windows;

namespace BoardApp
{
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();

        public void Register()
        {
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<AuthorizationViewModel>();
            Container.RegisterSingleton<SignUpViewModel>();

            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            var window = new MainView()
            {
                DataContext = Container.GetInstance<MainViewModel>()
            };
            window.ShowDialog();
        }
    }
}