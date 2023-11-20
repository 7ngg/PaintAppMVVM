using BoardApp.Infrastructure.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using BoardApp.ViewModels.Base;
using BoardApp.Services.Interfaces;
using BoardApp.Models;
using System.Windows.Ink;
using BoardApp.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace BoardApp.ViewModels
{
    public class BoardViewModel : MyViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;

        #region EditingModeProperty

        private InkCanvasEditingMode _currentEditingMode;
        public InkCanvasEditingMode CurrentEditingMode
        {
            get => _currentEditingMode;
            set => Set(ref _currentEditingMode, value);
        }

        #endregion

        public BoardModel CurrentBoard { get; set; } = new();
        public StrokeCollection Strokes { get; set; } = new();


        public BoardViewModel(IDataService dataService, INavigationService navigationService, IMessenger messenger)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            _messenger = messenger;

            _messenger.Register<BoardViewMessage>(this, message =>
            {
                if (message != null)
                {
                    CurrentBoard = message.UserData as BoardModel;
                }
            });

            PenButtonCommand = new LambdaCommand(OnPenButtonCommandExecuted);
            EraserButtomCommand = new LambdaCommand(OnEraserButtomCommandExecuted);
            SaveBoardCommand = new LambdaCommand(OnSaveBoardCommandExecuted, CanSaveBoardCommandExecute);

            OnPenButtonCommandExecuted();
        }


        #region Commands

        #region PenButtonCommand

        public ICommand PenButtonCommand { get; }
        private void OnPenButtonCommandExecuted() => CurrentEditingMode = InkCanvasEditingMode.Ink;

        #endregion

        #region EraserButtomCommand

        public ICommand EraserButtomCommand { get; }
        private void OnEraserButtomCommandExecuted() => CurrentEditingMode = InkCanvasEditingMode.EraseByPoint;

        #endregion

        #region SaveBoardCommand
        public ICommand SaveBoardCommand { get; }
        private bool CanSaveBoardCommandExecute() => true;
        private void OnSaveBoardCommandExecuted()
        {
            CurrentBoard.Strokes = Strokes;
            _dataService.SendData<BoardModel, BoardDataMessage>(CurrentBoard);
            _navigationService.NavigateTo<UserBoardsViewModel>();
        }

        #endregion

        #endregion
    }
}
