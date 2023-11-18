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
            Container.RegisterSingleton<IUserSerializationService, UserSerializationService>();
            Container.RegisterSingleton<IAuthorizationService, AuthorizationService>();
            Container.RegisterSingleton<IUserDialogService, UserDialogService>();
            Container.RegisterSingleton<IBoardSerializationService, BoardSerializationService>();
            Container.RegisterSingleton<IDataService, DataService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<AuthorizationViewModel>();
            Container.RegisterSingleton<SignUpViewModel>();

            Container.Register<UserBoardsViewModel>(Lifestyle.Transient);
            Container.Register<BoardViewModel>(Lifestyle.Transient);

            Container.Register<MainView>(() =>
            {
                var model = Container.GetInstance<MainViewModel>();
                var window = new MainView { DataContext = model };

                model.WindowClosed += (_, _) => window.Close();
                
                return window;
            }, Lifestyle.Transient);

            Container.Register<BoardView>(() =>
            {
                var model = Container.GetInstance<BoardViewModel>();
                var window = new BoardView { DataContext = model };

                model.WindowClosed += (_, _) => window.Close();

                return window;
            }, Lifestyle.Transient);

            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            Container.GetInstance<IUserDialogService>().OpenWindow<MainView>();
        }
    }
}
