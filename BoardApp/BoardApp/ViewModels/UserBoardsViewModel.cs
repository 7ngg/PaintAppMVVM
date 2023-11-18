using BoardApp.Infrastructure.Commands;
using BoardApp.Messages;
using BoardApp.Models;
using BoardApp.Services.Interfaces;
using BoardApp.ViewModels.Base;
using BoardApp.Views;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using System.Windows.Ink;
using System.Windows.Input;

namespace BoardApp.ViewModels
{
    internal class UserBoardsViewModel : MyViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogService _userDialogService;
        private readonly IDataService _dataService;
        private readonly IMessenger _messenger;

        private ObservableCollection<BoardModel> _userBoards;
        public ObservableCollection<BoardModel> UserBoards
        {
            get => _userBoards;
            set => Set(ref _userBoards, value);
        }

        public UserModel CurrentUser { get; set; }
        public BoardModel SelectedItem { get; set; }

        public UserBoardsViewModel(INavigationService navigationService, IUserDialogService userDialogService, IDataService dataService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _userDialogService = userDialogService;
            _dataService = dataService;
            _messenger = messenger;

            _messenger.Register<UserDataMessage>(this, message =>
            {
                if (message.UserData != null)
                {
                    CurrentUser = message.UserData as UserModel;
                }
            });

            SignOutCommand = new LambdaCommand(OnSignOutCommandExecuted);
            NewBoardCommand = new LambdaCommand(OnNewBoardCommandExecuted);
            SelectedItemDoubleClickCommand = new LambdaCommand(OnSelectedItemDoubleClickCommandExecuted, CanSelectedItemDoubleClickCommandExecute);

            //UserBoards = new()
            //{
            //    new BoardModel("Board 1", new StrokeCollection()),
            //    new BoardModel("Board 2", new StrokeCollection()),
            //    new BoardModel("Board 3", new StrokeCollection()),
            //};
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
            _dataService.SendData(new BoardModel());
            _userDialogService.OpenWindow<BoardView>();
        }

        #endregion

        #region SelectedItemDoubleClickCommand

        public ICommand SelectedItemDoubleClickCommand { get; }
        private bool CanSelectedItemDoubleClickCommandExecute() => SelectedItem == null;
        private void OnSelectedItemDoubleClickCommandExecuted()
        {
            _dataService.SendData(SelectedItem);
            _userDialogService.OpenWindow<BoardView>();
        }

        #endregion

        #endregion
    }
}
