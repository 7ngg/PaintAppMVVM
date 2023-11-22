using BoardApp.Converters;
using BoardApp.Infrastructure.Commands;
using BoardApp.Infrastructure.Messages;
using BoardApp.Models;
using BoardApp.Services.Interfaces;
using BoardApp.ViewModels.Base;
using BoardApp.Views;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BoardApp.ViewModels
{
    internal class UserBoardsViewModel : MyViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogService _userDialogService;
        private readonly IDataService _dataService;
        private readonly IMessenger _messenger;
        private readonly ISerializationService _serializationService;

        public UserModel CurrentUser { get; set; }
        public Board SelectedItem { get; set; }

        public UserBoardsViewModel(INavigationService navigationService, IUserDialogService userDialogService, IDataService dataService, IMessenger messenger, ISerializationService serializationService)
        {
            _navigationService = navigationService;
            _userDialogService = userDialogService;
            _dataService = dataService;
            _messenger = messenger;
            _serializationService = serializationService;

            _messenger.Register<UserDataMessage>(this, message =>
            {
                if (message.UserData != null)
                {
                    CurrentUser = message.UserData;
                }
            });

            _messenger.Register<BoardDataMessage>(this, message =>
            {
                if (message.UserData != null)
                {
                    var tmpBoard = message.UserData;
                    AddBoardToCurrentUser(tmpBoard);
                    _serializationService.Serialize(CurrentUser);
                }
            });

            SignOutCommand = new LambdaCommand(OnSignOutCommandExecuted);
            NewBoardCommand = new LambdaCommand(OnNewBoardCommandExecuted);
            SelectedItemDoubleClickCommand = new LambdaCommand(OnSelectedItemDoubleClickCommandExecuted, CanSelectedItemDoubleClickCommandExecute);
        }


        #region Commands

        #region SignOutCommand

        public ICommand SignOutCommand { get; set; }
        private void OnSignOutCommandExecuted() => _navigationService.NavigateTo<AuthorizationViewModel>();

        #endregion

        #region NewBoardCommand
        
        public ICommand NewBoardCommand { get; set; }
        private void OnNewBoardCommandExecuted()
        {
            _dataService.SendData<Board, BoardViewMessage>(new Board());
            _navigationService.NavigateTo<BoardViewModel>();
        }

        #endregion

        #region SelectedItemDoubleClickCommand

        public ICommand SelectedItemDoubleClickCommand { get; }
        private bool CanSelectedItemDoubleClickCommandExecute()
        {
            if (SelectedItem == null)
            {
                return false;
            }
            return true;
        }
        private void OnSelectedItemDoubleClickCommandExecuted()
        {
            _dataService.SendData<Board, BoardViewMessage>(SelectedItem);
            _navigationService.NavigateTo<BoardViewModel>();
        }

        #endregion

        #endregion

        #region Methods

        private void AddBoardToCurrentUser(Board board)
        {
            bool boardExists = false;

            foreach (var item in CurrentUser.Boards)    
            {
                if (item.Name == board.Name)
                {
                    item.Name = board.Name;
                    item.Strokes = board.Strokes;
                    boardExists = true;
                }
            }

            if (!boardExists)
            {
                CurrentUser.Boards.Add(board);
            }
        }

        #endregion
    }
}
