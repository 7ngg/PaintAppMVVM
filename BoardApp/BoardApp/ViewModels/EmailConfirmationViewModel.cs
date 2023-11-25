using BoardApp.Infrastructure.Commands;
using BoardApp.Infrastructure.Messages;
using BoardApp.Models;
using BoardApp.Services.Interfaces;
using BoardApp.ViewModels.Base;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using System.Windows.Input;

namespace BoardApp.ViewModels
{
    class EmailConfirmationViewModel : MyViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly IAuthorizationService _authorizationService;

        private UserModel _userToRegister;
        private OTPModel _otp;

        private string _code;
        public string Code
        {
            get => _code;
            set => Set(ref _code, value);
        }


        public EmailConfirmationViewModel(INavigationService navigationService, IMessenger messenger, IAuthorizationService authorizationService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _authorizationService = authorizationService;

            _messenger.Register<UserDataMessage>(this, message =>
            {
                if (message != null)
                {
                    _userToRegister = message.UserData;
                }
            });

            _messenger.Register<OTPMessage>(this, message =>
            {
                if (message != null)
                {
                    _otp = message.UserData;
                }
            });

            GoBackCommand = new LambdaCommand(OnGoBackCommandExecuted);
            ConfirmCommand = new LambdaCommand(OnConfirmCommandExecuted, CanConfirmCommandExecute);
        }


        #region GoBackCommand

        public ICommand GoBackCommand { get; }
        private void OnGoBackCommandExecuted() => _navigationService.NavigateTo<AuthorizationViewModel>();

        #endregion

        #region ConfirmCommand

        public ICommand ConfirmCommand { get; }
        private bool CanConfirmCommandExecute() => !string.IsNullOrWhiteSpace(Code) && Code.Length == 4;
        private void OnConfirmCommandExecuted()
        {
            if (_otp.OTP == Convert.ToInt32(Code))
            {
                _authorizationService.SignUp(_userToRegister.Username, _userToRegister.Password, _userToRegister.Email);
                MessageBox.Show("Sign up successful");
                _navigationService.NavigateTo<AuthorizationViewModel>();
            }
        }

        #endregion
    }
}
