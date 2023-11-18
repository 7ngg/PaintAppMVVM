using BoardApp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace BoardApp.Views
{
    /// <summary>
    /// Interaction logic for AuthorizationView.xaml
    /// </summary>
    public partial class AuthorizationView : UserControl
    {
        public AuthorizationView()
        {
            InitializeComponent();
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var model = App.Container.GetInstance<AuthorizationViewModel>();
            model.Password = passwordBox.Password;
        }
    }
}
