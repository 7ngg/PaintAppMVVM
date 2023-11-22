using BoardApp.Infrastructure.Messages;
using BoardApp.Services.Interfaces;
using BoardApp.ViewModels.Base;
using GalaSoft.MvvmLight.Messaging;

namespace BoardApp.Services.Classes
{
    class NavigationService : INavigationService
    {
        private readonly IMessenger _messenger;

        public NavigationService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void NavigateTo<T>() where T : MyViewModelBase
        {
            _messenger.Send(new NavigationMessage()
            {
                ViewModelType = App.Container.GetInstance<T>()
            });
        }
    }
}
