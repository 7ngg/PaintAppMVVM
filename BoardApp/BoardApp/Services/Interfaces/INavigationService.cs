using GalaSoft.MvvmLight;

namespace BoardApp.Services.Interfaces
{
    public interface INavigationService
    {
        public void NavigateTo<T>() where T : ViewModelBase;
    }
}
