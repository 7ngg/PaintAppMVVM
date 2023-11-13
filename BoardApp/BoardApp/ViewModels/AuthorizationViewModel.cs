using BoardApp.Infrastructure.Commands;
using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight;
using System.Windows;
using System.Windows.Input;

namespace BoardApp.ViewModels
{
    internal class AuthorizationViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthorizationService _authorizationService;

        public string Username { get; set; }
        public string Password { get; set; }


        public AuthorizationViewModel(INavigationService navigationService, IAuthorizationService authorizationService)
        {
            _navigationService = navigationService;
            _authorizationService = authorizationService;

            SignUpCommand = new LambdaCommand(OnSignUpCommandExecuted, CanSignUpCommandExecute);
            SignInCommand = new LambdaCommand(OnSignInCommandExecuted, CanSignInCommandExecute);
        }

#region Commands

    #region SignUpCommand

        public ICommand SignUpCommand { get; }
        private bool CanSignUpCommandExecute(object p) => true;
        private void OnSignUpCommandExecuted(object p) => _navigationService.NavigateTo<SignUpViewModel>();

    #endregion

    #region SignInCommand

        public ICommand SignInCommand { get; }
        private bool CanSignInCommandExecute(object p) => true;
        private void OnSignInCommandExecuted(object p)
        {
            if (_authorizationService.SignIn(Username, Password))
            {
                MessageBox.Show("Successful");
            }
        }

    #endregion

#endregion
    }
}
