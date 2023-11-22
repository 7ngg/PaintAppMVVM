using BoardApp.Infrastructure.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using BoardApp.ViewModels.Base;
using BoardApp.Services.Interfaces;
using BoardApp.Messages;
using GalaSoft.MvvmLight.Messaging;
using BoardApp.Models;
using System.Collections.Generic;
using System.Windows.Ink;
using BoardApp.Converters;

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

        public Board CurrentBoard { get; set; }
        private StrokeCollection _strokes;
        public StrokeCollection Strokes
        {
            get => _strokes;
            set => Set(ref _strokes, value);
        }

        public BoardViewModel(IDataService dataService, INavigationService navigationService, IMessenger messenger)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            _messenger = messenger;

            CurrentBoard = new();
            Strokes = new();

            _messenger.Register<BoardViewMessage>(this, message =>
            {
                if (message != null)
                {
                    CurrentBoard = message.UserData as Board;
                    Strokes = BoardConverter.RevertObject(message.UserData.Strokes);
                }
            });

            PenButtonCommand = new LambdaCommand(OnPenButtonCommandExecuted);
            EraserButtomCommand = new LambdaCommand(OnEraserButtomCommandExecuted);
            SaveBoardCommand = new LambdaCommand(OnSaveBoardCommandExecuted, CanSaveBoardCommandExecute);
            GoBackCommand = new LambdaCommand(OnGoBackCommandExecuted);

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
        private bool CanSaveBoardCommandExecute() => !string.IsNullOrEmpty(CurrentBoard.Name);
        private void OnSaveBoardCommandExecuted()
        {
            CurrentBoard.Strokes = BoardConverter.ConvertObject(Strokes);
            _dataService.SendData<Board, BoardDataMessage>(CurrentBoard);
            _navigationService.NavigateTo<UserBoardsViewModel>();
        }

        #endregion

        #region GoBackCommand

        public ICommand GoBackCommand { get; }
        private void OnGoBackCommandExecuted()
        {
            _navigationService.NavigateTo<UserBoardsViewModel>();
        }

        #endregion

        #endregion
    }
}
