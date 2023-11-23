using BoardApp.Services.Interfaces;
using System.Windows;

namespace BoardApp.Services.Classes
{
    public class UserDialogService : IUserDialogService
    {
        private Window _current;
        public void OpenWindow<T>() where T : Window, new()
        {
            if (_current is { } window)
            {
                window.Show();
            }

            window = App.Container.GetInstance<T>();
            window.Closed += (_, _) => _current = null;
            _current = window;
            window.ShowDialog();
        }
    }
}
