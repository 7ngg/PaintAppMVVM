using BoardApp.Infrastructure.Commands;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace BoardApp.ViewModels
{
    internal class BoardViewModel : Window
    {
        public InkCanvas canvas { get; set; } = new();

        public BoardViewModel()
        {
            CloseCommand = new LambdaCommand(OnCloseCommandExecuted, CanCloseCommandExecute);
            MaximizeCommand = new LambdaCommand(OnMaximizeCommandExecuted, CanMaximizeCommandExecute);
            MinimizeCommand = new LambdaCommand(OnMinimizeCommandExecuted, CanMinimizeCommandExecute);
            EraserButtomCommand = new LambdaCommand(OnEraserButtomCommandExecuted, CanEraserButtomCommandExecute);
        }

        #region CloseCommand

        public ICommand CloseCommand { get; }
        private bool CanCloseCommandExecute(object p) => true;
        private void OnCloseCommandExecuted(object p) => App.Current.Shutdown();

        #endregion

        #region MaximizeCommand
        
        public ICommand MaximizeCommand { get; }
        public bool CanMaximizeCommandExecute(object p) => true;
        private void OnMaximizeCommandExecuted(object p)
        {
            if (App.Current.MainWindow.WindowState == System.Windows.WindowState.Normal)
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
            }
        }

        #endregion

        #region MinimizeCommand

        public ICommand MinimizeCommand { get; }
        private bool CanMinimizeCommandExecute(object p) => true;
        private void OnMinimizeCommandExecuted(object p) => App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;

        #endregion

        #region EraserButtomCommand

        public ICommand EraserButtomCommand { get; }
        private bool CanEraserButtomCommandExecute(object p) => true;
        private void OnEraserButtomCommandExecuted(object p) => canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;

        #endregion
    }
}
