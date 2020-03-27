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

        private bool _userNameEnabled = true;
        public bool UserNameEnabled
        {
            get => _userNameEnabled;
            set
            {
                _userNameEnabled = value;
                OnPropertyChanged(() => UserNameEnabled);
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

        private Visibility _passwordVisible = Visibility.Visible;
        public Visibility PasswordVisible
        {
            get => _passwordVisible;
            set
            {
                _passwordVisible = value;
                OnPropertyChanged(() => PasswordVisible);
            }
        }

        private Visibility _newPasswordVisible = Visibility.Collapsed;
        public Visibility NewPasswordVisible
        {
            get => _newPasswordVisible;
            set
            {
                _newPasswordVisible = value;
                OnPropertyChanged(() => NewPasswordVisible);
            }
        }

        private bool _changePwd;
        public bool ChangePwd
        {
            get => _changePwd;
            set
            {
                _changePwd = value;
                NewPasswordVisible = value ? Visibility.Visible : Visibility.Collapsed;
                OnPropertyChanged(() => ChangePwd);
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

        private bool _remember;
        public bool Remember
        {
            get => _remember;
            set
            {
                _remember = value;
                OnPropertyChanged(() =>  Remember);
            }
        }

        #endregion

        #region * * * METHODS * * *

        private static bool IsPasswordStrong(string password)
        {
            return password.Length >= 8
                && Regex.IsMatch(password, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript)
                && Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$", RegexOptions.ECMAScript)
                && Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript);
        }

        private void AuthorizationThroughWindows(Window window)
        {
            var identity = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity;
            UserInfo.UserLogin = identity.Name;
            UserInfo.UserName = identity.Name;
            UserInfo.UserRole = "Default User";
            
            window.DialogResult = true;
            window.Close();
        }

        private void AuthorizationThroughServerAccount(LoginWindow window)
        {
            IsBusy = true;
            PermitApiProxy.UserLogin = User.UserName;
            PermitApiProxy.UserPassword = User.PlainPassword;
            //PermitApiProxy.BaseUri = ConfigurationManager.AppSettings["SmRoPermitApiBaseUri"];
            PermitApiProxy.BaseUri = GetPermitUri();

            if (NewPasswordVisible !=  Visibility.Visible)
            {
                PermitApiProxy.UserLogin = User.UserName;
                PermitApiProxy.UserPassword = User.PlainPassword;
                RspLogin rsp = PermitApiProxy.Login();
                IsBusy = false;
                if (rsp.Result == RspLogin.LoginResult.Success)
                {
                    User.CodeI = rsp.UserCodeI;
                    window.DialogResult = true;
                    window.Close();
                }
                else if (rsp.Result == RspLogin.LoginResult.Failed)
                {
                    MessageBox.Show("Invalid login and/or password. Please, change and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (rsp.Result == RspLogin.LoginResult.ChangePassword)
                {
                    MessageBox.Show("Please, change password", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    PasswordVisible = Visibility.Collapsed;
                    NewPasswordVisible = Visibility.Visible;
                    return;
                }
            }
            else
            {
                if (!User.PlainNewPassword.Equals(User.PlainConfirmPassword))
                {
                    IsBusy = false;
                    MessageBox.Show("Input passwords are not the same. Please, change and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!IsPasswordStrong(User.PlainNewPassword))
                {
                    IsBusy = false;
                    MessageBox.Show("Password is not strong enough. Please. make sure that it is not less than 8 characters in length and contains digits, letters in lower and upper cases, and at least one special character.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                RspLogin res = PermitApiProxy.ChangePasswordAndLogin(User.UserName, User.PlainPassword, User.PlainNewPassword);
                if (res.Result == RspLogin.LoginResult.Failed)
                {
                    IsBusy = false;
                    MessageBox.Show("Invalid login and/or password. Please, change and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                IsBusy = false;
                User.CodeI = res.UserCodeI;
                User.Password = User.NewPassword;
                window.DialogResult = true;
                window.Close();
            }
        }

        private string GetPermitUri()
        {
            string configName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "workplace.config");
            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
            configFile.ExeConfigFilename = configName;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);

            string uri = config.AppSettings.Settings["SmRoPermitApiBaseUri"].Value;
            return uri;
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoginCommand => new IPSDelegateCommand(LoginCommandExecute, CanExecuteLoginCommand);
        private void LoginCommandExecute(object o)
        {
            try
            {
                var window = (LoginWindow) o;
                User.Password = window.pwBox.SecurePassword;
                User.NewPassword = window.newPwBox.SecurePassword;
                User.ConfirmPassword = window.confirmPwBox.SecurePassword;
                AuthorizationThroughServerAccount(window);
            }
            catch(Exception e)
            {
                //MessageBox.Show("Failed to connect to the permissions server. Please. make sure that it is running and application has correct URI in configuration", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                var dialogService = new DialogService();
                string message = "Failed to connect to the permissions server. Please. make sure that it is running and application has correct URI in configuration";
                dialogService.ShowError(message, e.ToString());
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand CancelCommand => new IPSDelegateCommand(CancelCommandExecute);
        private void CancelCommandExecute(object o)
        {
            var window = (LoginWindow)o;
            window.Close();
        }

        private bool CanExecuteLoginCommand(object o)
        {
            if (PasswordVisible != Visibility.Visible)
                return true;
            var pbValid = (o as LoginWindow)?.pwBox?.Password.Length >= 8;
            
            var result = (!string.IsNullOrEmpty(User.UserName) && ((o as bool? ?? false) || pbValid)) || Remember;
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
                var window =
                    ((FrameworkElement) ((FrameworkElement) (
                            (FrameworkElement) ((FrameworkElement)
                                ((FrameworkElement) ((FrameworkElement)
                                    ((FrameworkElement) key.Source).Parent).Parent).Parent).Parent)
                        .Parent)
                        .Parent).Parent as LoginWindow;
                if (window == null)
                    return;

                if (LoginCommand.CanExecute(window))
                    LoginCommand.Execute(window);
            }
        }

        #endregion
    }
}
