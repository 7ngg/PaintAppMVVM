using System.Windows;

namespace BoardApp.Services.Interfaces
{
    public interface IUserDialogService
    {
        void OpenWindow<T>() where T : Window, new();
    }
}
