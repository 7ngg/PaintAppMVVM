using BoardApp.Infrastructure.Commands;
using BoardApp.Services.Interfaces;
using System.Windows.Input;
using BoardApp.Infrastructure.Regexes;
using BoardApp.ViewModels.Base;
using BoardApp.Models;
using System.Windows.Controls;
using BoardApp.Infrastructure.Messages;

namespace BoardApp.ViewModels
{
    public class AuthorizationViewModel : MyViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IDataService _dataService;
        public UserModel _currentUser;

        public string Username { get; set; }

        private string _password;
        public string Password {
            get => _password;
            set => Set(ref _password, value);
        }


        public AuthorizationViewModel(INavigationService navigationService, IAuthorizationService authorizationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _authorizationService = authorizationService;

            Username = string.Empty;
            Password = string.Empty;

            GoToRegistrationCommand = new LambdaCommand(OnGoToRegistrationCommandExecuted);
            SignInCommand = new LambdaCommand(OnSignInCommandExecuted, CanSignInCommandExecute);
            _dataService = dataService;
        }

        #region Commands

        #region SignUpCommand

        public ICommand GoToRegistrationCommand { get; }
        private void OnGoToRegistrationCommandExecuted() => _navigationService.NavigateTo<SignUpViewModel>();

        #endregion

        #region SignInCommand

        public ICommand SignInCommand { get; }
        private bool CanSignInCommandExecute(object param)
        {
            if (param != null)
            {
                object[] res = (object[])param;

                var password = (PasswordBox)res[0];
                Password = password.Password.ToString();

                if (UserModelRegex.UsernameRegex.IsMatch(Username) && UserModelRegex.PasswordRegex.IsMatch(Password))
                {
                    return true;
                }
            }

            return false;
        }
        private void OnSignInCommandExecuted(object param)
        {
            _currentUser = _authorizationService.SignIn(Username, Password);    
                
            if (_currentUser != null)
            {
                _dataService.SendData<UserModel, UserDataMessage>(_currentUser);

                _navigationService.NavigateTo<UserBoardsViewModel>();
            }
        }

        #endregion

        #endregion
    }
}
