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
