using BoardApp.Infrastructure.Commands;
using BoardApp.Infrastructure.Messages;
using BoardApp.Infrastructure.Regexes;
using BoardApp.Models;
using BoardApp.Services.Interfaces;
using BoardApp.ViewModels.Base;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace BoardApp.ViewModels
{
    internal class SignUpViewModel : MyViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IOTPService _otpService;

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

        public SignUpViewModel(INavigationService navigationService, IDataService dataService, IOTPService otpService)
        {
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;

            _navigationService = navigationService;
            _dataService = dataService;
            _otpService = otpService;

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
        private bool CanSignUpCommandExecute(object param)
        {
            if (param != null)
            {
                object[] res = (object[])param;

                var password = (PasswordBox)res[0];
                var confirm = (PasswordBox)res[1];
                Password = password.Password.ToString();
                ConfirmPassword = confirm.Password.ToString();

                if (Password == ConfirmPassword && ValidateInputs())
                {
                    return true;
                }
            }

            return false;
        }
        private void OnSignUpCommandExecuted()
        {
            var code = _otpService.SendOTP(Email);
            _dataService.SendData<OTPModel, OTPMessage>(code);
            _dataService.SendData<UserModel, UserDataMessage>(new(Username, Password, Email));
            _navigationService.NavigateTo<EmailConfirmationViewModel>();
        }

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
