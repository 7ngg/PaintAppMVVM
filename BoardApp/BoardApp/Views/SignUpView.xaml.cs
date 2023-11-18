using BoardApp.ViewModels;
using BoardApp.ViewModels.Base;
using System.Windows;
using System.Windows.Controls;

namespace BoardApp.Views
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {

        public SignUpView()
        {
            InitializeComponent();
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var model = App.Container.GetInstance<SignUpViewModel>();
            model.Password = password.Password;
        }

        private void confirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var model = App.Container.GetInstance<SignUpViewModel>();
            model.ConfirmPassword = confirmPassword.Password;
        }
    }
}
