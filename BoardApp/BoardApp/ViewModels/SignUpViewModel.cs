using BoardApp.Infrastructure.Commands;
using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight;
using System.Windows.Input;

namespace BoardApp.ViewModels
{
    internal class SignUpViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthorizationService _authorizationService;

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public SignUpViewModel(INavigationService navigationService, IAuthorizationService authorizationService)
        {
            _navigationService = navigationService;
            _authorizationService = authorizationService;

            GoBackCommand = new LambdaCommand(OnGoBackCommandExecuted, CanGoBackCommandExecute);
            SignUpCommand = new LambdaCommand(OnSignUpCommandExecuted, CanSignUpCommandExecute);
        }


        #region GoBackCommand

        public ICommand GoBackCommand { get; }
        private bool CanGoBackCommandExecute(object p) => true;
        private void OnGoBackCommandExecuted(object p) => _navigationService.NavigateTo<AuthorizationViewModel>();

        #endregion

        #region SignUpCommand

        public ICommand SignUpCommand { get; }
        private bool CanSignUpCommandExecute(object p) => true;
        private void OnSignUpCommandExecuted(object p) => _authorizationService.SignUp(Username, Password, Email);

        #endregion
    }
}
