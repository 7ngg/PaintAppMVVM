using BoardApp.Infrastructure.Commands;
using BoardApp.Infrastructure.Regexes;
using BoardApp.Services.Interfaces;
using BoardApp.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace BoardApp.ViewModels
{
    internal class SignUpViewModel : MyViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthorizationService _authorizationService;

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

        public SignUpViewModel(INavigationService navigationService, IAuthorizationService authorizationService)
        {
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;

            _navigationService = navigationService;
            _authorizationService = authorizationService;

            GoBackCommand = new LambdaCommand(OnGoBackCommandExecuted, CanGoBackCommandExecute);
            SignUpCommand = new LambdaCommand(OnSignUpCommandExecuted, CanSignUpCommandExecute);
        }

        #region Commands

        #region GoBackCommand

        public ICommand GoBackCommand { get; }
        private bool CanGoBackCommandExecute() => true;
        private void OnGoBackCommandExecuted() => _navigationService.NavigateTo<AuthorizationViewModel>();

        #endregion

        #region SignUpCommand

        public ICommand SignUpCommand { get; }
        private bool CanSignUpCommandExecute()
        {
            if (ValidateInputs()) return true;
            return false;
        }
        private void OnSignUpCommandExecuted() => _authorizationService.SignUp(Username, Password, Email);

        #endregion

        #endregion

        private bool ValidateInputs()
        {
            bool UsernameFlag = UserModelRegex.UsernameRegex.IsMatch(Username);
            bool PasswordFlag = (Password == ConfirmPassword) && UserModelRegex.PasswordRegex.IsMatch(Password);
            bool EmailFlag = UserModelRegex.EmailRegex.IsMatch(Email);

            return UsernameFlag && PasswordFlag && EmailFlag;
        }
    }
}
