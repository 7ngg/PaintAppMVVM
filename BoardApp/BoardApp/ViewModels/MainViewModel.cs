using BoardApp.Infrastructure.Commands;
using BoardApp.Infrastructure.Messages;
using BoardApp.Services.Interfaces;
using BoardApp.ViewModels.Base;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace BoardApp.ViewModels
{
    class MainViewModel : MyViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;

        private int _windowHeight = 760;
        public int WindowHeight
        {
            get => _windowHeight;
            set => Set(ref _windowHeight, value);
        }

        private int _windowWidth = 450;
        public int WindowWidth
        {
            get => _windowWidth;
            set => Set(ref _windowWidth, value);
        }
        
        private MyViewModelBase _currentView;
        public MyViewModelBase CurrentView
        {
            get => _currentView;
            set => Set(ref _currentView, value);
        }


        public MainViewModel(IMessenger messenger, INavigationService navigationService)
        {
            CurrentView = App.Container.GetInstance<AuthorizationViewModel>();

            _messenger = messenger;
            _navigationService = navigationService;

            _messenger.Register<WindowPropertyMessage>(this, message =>
            {
                if (message != null)
                {
                    WindowWidth = message.UserData.Windth;
                    WindowHeight = message.UserData.Height;
                }
            });

            _messenger.Register<NavigationMessage>(this, message =>
            {
                CurrentView = message.ViewModelType;
            });

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
        }

        #region CloseAppCommand

        public ICommand CloseAppCommand { get; }
        private bool CanCloseAppCommandExecute() => true;
        private void OnCloseAppCommandExecuted() => App.Current.Shutdown();
       
        #endregion
    }
}
