using BoardApp.Infrastructure.Commands;
using BoardApp.Services.Interfaces;
using System.Windows;
using System.Windows.Input;
using BoardApp.Infrastructure.Regexes;
using BoardApp.ViewModels.Base;

namespace BoardApp.ViewModels
{
    internal class AuthorizationViewModel : MyViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthorizationService _authorizationService;

        public string Username { get; set; }

        private string _password;
        public string Password {
            get => _password;
            set => Set(ref _password, value);
        }


        public AuthorizationViewModel(INavigationService navigationService, IAuthorizationService authorizationService)
        {
            _navigationService = navigationService;
            _authorizationService = authorizationService;

            Username = string.Empty;
            Password = string.Empty;

            GoToRegistrationCommand = new LambdaCommand(OnGoToRegistrationCommandExecuted);
            SignInCommand = new LambdaCommand(OnSignInCommandExecuted, CanSignInCommandExecute);
        }

        #region Commands

        #region SignUpCommand

        public ICommand GoToRegistrationCommand { get; }
        private void OnGoToRegistrationCommandExecuted() => _navigationService.NavigateTo<SignUpViewModel>();

        #endregion

        #region SignInCommand

        public ICommand SignInCommand { get; }
        private bool CanSignInCommandExecute()
        {
            if (UserModelRegex.UsernameRegex.IsMatch(Username) && UserModelRegex.PasswordRegex.IsMatch(Password))
            {
                return true;
            }

            return false;
        }
        private void OnSignInCommandExecuted()
        {
            if (_authorizationService.SignIn(Username, Password))
            {
                MessageBox.Show("Successful");
                _navigationService.NavigateTo<UserBoardsViewModel>();
            }
        }

        #endregion

        #endregion
    }
}
