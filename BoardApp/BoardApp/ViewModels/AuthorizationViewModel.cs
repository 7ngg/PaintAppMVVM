using BoardApp.Infrastructure.Commands;
using BoardApp.Services.Interfaces;
using BoardApp.ViewModels.Base;
using GalaSoft.MvvmLight;
using System.Windows.Input;

namespace BoardApp.ViewModels
{
    internal class AuthorizationViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;


#region Commands

    #region CloseAppCommand

        //public ICommand CloseAppCommand { get; }
        //private bool CanCloseAppCommandExecute(object p) => true;
        //private void OnCloseAppCommandExecuted(object p) => App.Current.Shutdown();

    #endregion

    #region SignUpCommand

        public ICommand SignUpCommand { get; }
        private bool CanSignUpCommandExecute(object p) => true;
        private void OnSignUpCommandExecuted(object p) => _navigationService.NavigateTo<SignUpViewModel>();

    #endregion

#endregion

        public AuthorizationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            //CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
            SignUpCommand = new LambdaCommand(OnSignUpCommandExecuted, CanSignUpCommandExecute);
        }
    }
}
