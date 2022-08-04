using Launcher.Controls.LoginWindow;
using SmRoPermitClientLib;
using SmRoPermitCommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Launcher.Controls
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {

        private UserModel User { get; set; }

        public RspLogin Response { get; set; }

        private bool _isTempPassword;
        private bool IsTempPassword
        {
            get => _isTempPassword;
            set
            {
                _isTempPassword = value;

                if (value)
                    oldPasswordStack.Visibility = Visibility.Collapsed;
            }
        }

        public ChangePassword(UserModel user, bool tempChanging)
        {
            InitializeComponent();
            User = user;
            IsTempPassword = tempChanging;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (IsTempPassword)
                RunChangePassword();
            else
                ChangeCurrentPassword();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ChangeCurrentPassword()
        {
            if (oldPassword.SecurePassword.Length == 0)
                return;

            User.Password = oldPassword.SecurePassword;
            PermitApiProxy.UserPassword = User.PlainPassword;
            RspLogin response = PermitApiProxy.Login();
            if (response.Result == RspLogin.LoginResult.Success)
            {
                RunChangePassword();
            }
            else if (response.Result == RspLogin.LoginResult.Failed)
            {
                MessageBox.Show("Invalid old password. Please, change and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RunChangePassword()
        {
            if (newPassword.SecurePassword.Length == 0 || newPasswordConfirm.SecurePassword.Length == 0)
                return;

            User.NewPassword = newPassword.SecurePassword;
            User.ConfirmPassword = newPasswordConfirm.SecurePassword;

            if (IsValidPassword())
            {
                RspLogin res = PermitApiProxy.ChangePasswordAndLogin(User.UserName, User.PlainPassword, User.PlainNewPassword);
                if (res.Result == RspLogin.LoginResult.Failed)
                {
                    MessageBox.Show("Invalid login and/or password. Please, change and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Response = res;

                User.CodeI = res.UserCodeI;
                User.Password = User.NewPassword;
                MessageBox.Show("Password has been changed!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
        }

        private bool IsValidPassword()
        {
            if (!User.PlainNewPassword.Equals(User.PlainConfirmPassword))
            {
                MessageBox.Show("Input passwords are not the same. Please, change and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!IsPasswordStrong(User.PlainNewPassword))
            {
                MessageBox.Show("Password is not strong enough. Please, make sure that it is not less than 8 characters in length and contains digits, letters in lower and upper cases.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private static bool IsPasswordStrong(string password)
        {
            return password.Length >= 8
                && Regex.IsMatch(password, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript)
                && Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$", RegexOptions.ECMAScript)
                //&& Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript)
                ;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
