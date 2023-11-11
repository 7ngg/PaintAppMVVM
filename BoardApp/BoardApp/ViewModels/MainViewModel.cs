using BoardApp.Infrastructure.Commands;
using BoardApp.Messages;
using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace BoardApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => Set(ref _currentView, value);
        }


        public MainViewModel(IMessenger messenger, INavigationService navigationService)
        {
            CurrentView = App.Container.GetInstance<AuthorizationViewModel>();

            _messenger = messenger;
            _navigationService = navigationService;

            _messenger.Register<NavigationMessage>(this, message =>
            {
                CurrentView = message.ViewModelType;
            });

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
        }

        #region CloseAppCommand

        public ICommand CloseAppCommand { get; }
        private bool CanCloseAppCommandExecute(object p) => true;
        private void OnCloseAppCommandExecuted(object p) => App.Current.Shutdown();
       
        #endregion
    }
}
