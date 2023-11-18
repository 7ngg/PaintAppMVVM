using BoardApp.Infrastructure.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using BoardApp.ViewModels.Base;
using BoardApp.Services.Interfaces;
using System.Windows.Ink;
using System.IO;
using BoardApp.Models;
using GalaSoft.MvvmLight.Messaging;
using BoardApp.Messages;

namespace BoardApp.ViewModels
{
    public class BoardViewModel : MyViewModelBase
    {
        private readonly IBoardSerializationService _boardSerializationService;
        private readonly IMessenger _messenger;
        
        private InkCanvasEditingMode _currentEditingMode;

        public BoardModel CurrentBoard { get; set; } = new();

        public InkCanvasEditingMode CurrentEditingMode
        {
            get => _currentEditingMode;
            set => Set(ref _currentEditingMode, value);
        }


        public BoardViewModel(IBoardSerializationService boardSerializationService, IMessenger messenger)
        {
            _boardSerializationService = boardSerializationService;
            _messenger = messenger;

            _messenger.Register<UserDataMessage>(this, message =>
            {
                if (message.UserData != null)
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
            string rootDirectory = @"C:\Users\tng\itstep-Projects\BoardApp\BoardApp\bin\Debug\net6.0-windows";
            string targetDirectory = Path.Combine(rootDirectory, CurrentBoard.Name);

            if(!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            _boardSerializationService.Serialize(CurrentBoard);
        }

        #endregion

        #endregion
    }
}
