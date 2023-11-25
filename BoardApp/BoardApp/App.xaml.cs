using BoardApp.Services.Classes;
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
            Container.RegisterSingleton<IAuthorizationService, AuthorizationService>();
            Container.RegisterSingleton<IUserDialogService, UserDialogService>();
            Container.RegisterSingleton<IDataService, DataService>();
            Container.RegisterSingleton<ISerializationService, SerializationService>();
            Container.RegisterSingleton<IOTPService, OTPService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<AuthorizationViewModel>();
            Container.RegisterSingleton<SignUpViewModel>();
            Container.RegisterSingleton<EmailConfirmationViewModel>();
            Container.RegisterSingleton<UserBoardsViewModel>();
            Container.RegisterSingleton<BoardViewModel>();

            Container.RegisterSingleton<MainView>(() =>
            {
                var model = Container.GetInstance<MainViewModel>();
                var window = new MainView { DataContext = model };

                model.WindowClosed += (_, _) => window.Close();
                
                return window;
            });

            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            Container.GetInstance<IUserDialogService>().OpenWindow<MainView>();
        }
    }
}
