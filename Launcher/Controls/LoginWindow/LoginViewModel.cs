using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IpsViewComponentLibrary.Utilities;
using IPSViewComponentLibraryWPF.IPSExtensions;
using SmRoPermitClientLib;
using SmRoPermitCommonLib;
using Telerik.Windows.Controls;

namespace Launcher.Controls.LoginWindow
{
    public class LoginViewModel : ViewModelBase
    {
        public event Action<bool> Close;

        public LoginViewModel()
        {
            WindowUpEventCommand.Execute(null);
        }

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

        private Visibility _capsLockOnVisibility = Visibility.Visible;
        public Visibility CapsLockOnVisibility
        {
            get => _capsLockOnVisibility;
            set
            {
                _capsLockOnVisibility = value;
                OnPropertyChanged(() => CapsLockOnVisibility);
            }
        }

        #endregion

        #region * * * DATA PROPERTIES * * *

        private UserModel _user;
        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(() => User);
            }
        }

        #endregion

        #region * * * METHODS * * *

        private void AuthorizationThroughWindows(Window window)
        {
            var identity = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity;
            User.UserName = identity.Name;
            User.Name = identity.Name;
            User.UserRole = "Default User";
            
            window.DialogResult = true;
            window.Close();
        }

        private void AuthorizationThroughServerAccount()
        {
            IsBusy = true;
            PermitApiProxy.UserLogin = User.UserName;
            PermitApiProxy.UserPassword = User.PlainPassword;
            PermitApiProxy.BaseUri = GetPermitUri();

            RspLogin response = PermitApiProxy.Login();
            IsBusy = false;
            if (response.Result == RspLogin.LoginResult.Success)
            {
                SuccessLogin(response);
            }
            else if (response.Result == RspLogin.LoginResult.Failed)
            {
                MessageBox.Show("Invalid login and/or password. Please, change and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (response.Result == RspLogin.LoginResult.ChangePassword)
            {
                MessageBox.Show("Please, change password", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                ChangePassword changePassword = new ChangePassword(User, true);
                var result = changePassword.ShowDialog();
                if (result ?? false)
                {
                    SuccessLogin(changePassword.Response);
                }
                return;
            }
        }

        private void SuccessLogin(RspLogin response)
        {
            User.CodeI = response.UserCodeI;
            User.Name = response.Name;
            Close.Invoke(true);
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoginCommand => new IPSDelegateCommand(LoginCommandExecute, CanExecuteLoginCommand);
        private void LoginCommandExecute(object o)
        {
            try
            {
                var passwordBox = (PasswordBox) o;
                User.Password = passwordBox.SecurePassword;
                AuthorizationThroughServerAccount();
            }
            catch(Exception e)
            {
                var dialogService = new DialogService();
                string message = "Failed to connect to the permissions server. Please. make sure that it is running and application has correct URI in configuration";
                dialogService.ShowError(message, e.ToString());
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanExecuteLoginCommand(object o)
        {
            var pbValid = (o as PasswordBox)?.SecurePassword.Length >= 8;
            var result = !string.IsNullOrEmpty(User?.UserName) && ((o as bool? ?? false) || pbValid);
            CanLogin = result;
            return result;
        }

        private bool CanLogin { get; set; }

        public ICommand KeyUpCommand => new IPSDelegateCommand(KeyUpCommandExecute);
        private void KeyUpCommandExecute(object o)
        {
            if (!CanLogin)
                return;

            var key = (KeyEventArgs) o;
            if (key.Key == Key.Enter)
            {
                var passwordBox = ((RoutedEventArgs)o).Source as PasswordBox;
                if (passwordBox == null)
                    return;

                if (LoginCommand.CanExecute(passwordBox))
                    LoginCommand.Execute(passwordBox);
            }
        }

        public ICommand WindowUpEventCommand => new IPSDelegateCommand(WindowUpEventCommandExecute);
        private void WindowUpEventCommandExecute(object o)
        {
            CapsLockOnVisibility = Keyboard.IsKeyToggled(Key.CapsLock) ? Visibility.Visible : Visibility.Hidden;
        }

        #endregion

        private static string GetPermitUri()
        {
            string configName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "workplace.config");
            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
            configFile.ExeConfigFilename = configName;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);

            string uri = config.AppSettings.Settings["SmRoPermitApiBaseUri"].Value;
            return uri;
        }
    }
}
