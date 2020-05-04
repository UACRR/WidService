using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Launcher.Controls.LoginWindow
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void AuthType_Selected(object sender, RoutedEventArgs e)
        {
            var dc = (LoginViewModel)DataContext;
            ComboBox comboBox = (ComboBox)sender;
            var userName = FindName("UserName");
            if(comboBox.SelectedIndex == 0)
            {
                dc.PasswordVisible = Visibility.Collapsed;
                dc.NewPasswordVisible = Visibility.Collapsed;
                dc.UserNameEnabled = false;
                dc.User.UserName = WindowsIdentity.GetCurrent().Name;
                dc.User.Password = new System.Security.SecureString();
                dc.LoginEnabled = true;
                if (userName != null)
                    ((TextBox)userName).Text = dc.User.UserName;
            }
            else
            {
                dc.PasswordVisible = Visibility.Visible;
                dc.NewPasswordVisible = Visibility.Collapsed;
                dc.UserNameEnabled = true;
                dc.User.UserName = "";
                dc.User.Password = new System.Security.SecureString();
                dc.User.NewPassword = new System.Security.SecureString();
                dc.User.ConfirmPassword = new System.Security.SecureString();
                dc.ChangePwd = false;
                if (userName != null)
                    ((TextBox)userName).Text = dc.User.UserName;
            }
        }
 
    }
}
