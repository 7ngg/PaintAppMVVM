using BoardApp.Infrastructure.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using BoardApp.ViewModels.Base;
using BoardApp.Services.Interfaces;
using BoardApp.Models;
using System.Windows.Ink;

namespace BoardApp.ViewModels
{
    public class BoardViewModel : MyViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly IUserDialogService _userDialogService;

        #region EditingModeProperty

        private InkCanvasEditingMode _currentEditingMode;
        public InkCanvasEditingMode CurrentEditingMode
        {
            get => _currentEditingMode;
            set => Set(ref _currentEditingMode, value);
        }

        #endregion

        public BoardModel CurrentBoard { get; set; }
        public StrokeCollection Strokes { get; set; } = new();


        public BoardViewModel(IDataService dataService, IUserDialogService userDialogService)
        {
            _dataService = dataService;
            _userDialogService = userDialogService;

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
            _dataService.SendData(CurrentBoard);
        }

        #endregion

        #endregion
    }
}
