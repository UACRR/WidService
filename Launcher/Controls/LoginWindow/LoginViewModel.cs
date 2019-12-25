using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.Windows.Controls;

namespace Launcher.Controls.LoginWindow
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel() {}

        #region * * * BEHAVIOR PROPERTIES * * *

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(() => IsBusy);
            }
        }

        private bool _loginEnabled = true;
        public bool LoginEnabled
        {
            get => _loginEnabled;
            set
            {
                _loginEnabled = value;
                OnPropertyChanged(() => LoginEnabled);
            }
        }

        private bool _passwordEnabled = true;
        public bool PasswordEnabled
        {
            get => _passwordEnabled;
            set
            {
                _passwordEnabled = value;
                OnPropertyChanged(() => PasswordEnabled);
            }
        }

        #endregion

        #region * * * DATA PROPERTIES * * *

        private LoginModel _user = new LoginModel();
        public LoginModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(() => User);
            }
        }

        private UserInfoModel _userInfo = new UserInfoModel();
        public UserInfoModel UserInfo
        {
            get => _userInfo;
            set
            {
                _userInfo = value;
                OnPropertyChanged(() => UserInfo);
            }
        }

        private bool _windowsAuthentication;
        public bool WindowsAuthentication
        {
            get => _windowsAuthentication;
            set
            {
                _windowsAuthentication = value;
                LoginEnabled = !value;
                PasswordEnabled = !value;
                OnPropertyChanged(() =>  WindowsAuthentication);
            }
        }

        #endregion

        #region * * * METHODS * * *

        private void AuthorizationThroughWindows(Window window)
        {
            var identity = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity;
            UserInfo.UserLogin = identity.Name;
            UserInfo.UserName = identity.Name;
            UserInfo.UserRole = "Default User";
            
            window.DialogResult = true;
            window.Close();
        }

        private async void AuthorizationThroughServerAccount(Window window)
        {
            // send request
            IsBusy = true;
            await Task.Delay(965);
            IsBusy = false;

            MessageBox.Show("Unknown user!", "Not authorized", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoginCommand => new IPSDelegateCommand(LoginCommandExecute, CanExecuteLoginCommand);
        private void LoginCommandExecute(object o)
        {
            var window = (LoginWindow) o;
            if (WindowsAuthentication)
            {
                AuthorizationThroughWindows(window);
            }
            else
            {
                var pb = window.pwBox;
                User.Password = pb.SecurePassword;
                AuthorizationThroughServerAccount(window);
            }
        }

        private bool CanExecuteLoginCommand(object o)
        {
            var pbValid = (o as LoginWindow)?.pwBox?.Password.Length >= 6;
            
            var result = (!string.IsNullOrEmpty(User.UserName) && ((o as bool? ?? false) || pbValid)) || WindowsAuthentication;
            return result;
        }

        #endregion
    }
}
