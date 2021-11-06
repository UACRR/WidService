using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DdexInvoicing;
using ipsFormsDesign.Data;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Utilities;
using IPSViewComponentLibraryWPF.IPSExtensions;
using LanguageLibrary;
using LanguageLibrary.Model;
using Launcher.Controls.LoginWindow;
using Launcher.WorkplaceModules.ClientsBRWorkplace;
using Launcher.WorkplaceModules.ClientsSRWorkplace;
using Launcher.WorkplaceModules.CopyrightAdminWorkplace;
using Launcher.WorkplaceModules.FinishingWorksWorkplace;
using Launcher.WorkplaceModules.PartnerWorkplace;
using Launcher.WorkplaceModules.ReportWorkplace;
using SmRoPermitAdmin;
using SmRoPermitClientLib;
using SmRoPermitCommonLib;
using Telerik.Windows.Controls;

namespace Launcher
{
    public class LauncherViewModel : ViewModelBase
    {
        private string _authString;
        public LauncherViewModel()
        {
            UserInfoVisibility = Visibility.Collapsed;
        }

        #region * * * BEHAVIOR PROPERTIES * * *

        private bool _isBusy;
        /// <summary>
        /// Індщикатор зайнятості
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(() => IsBusy);
            }
        }

        private bool _isSignIn;
        private bool IsSignIn
        {
            get => _isSignIn;
            set
            {
                _isSignIn = value;
                LoginButtonVisibility = value ? Visibility.Collapsed : Visibility.Visible;
                UserInfoVisibility = value ? Visibility.Visible : Visibility.Collapsed;
                OnPropertyChanged(() => IsSignIn);
            }
        }

        private bool IsInit { get; set; }

        private Visibility _loginButtonVisibility = Visibility.Visible;
        public Visibility LoginButtonVisibility
        {
            get => _loginButtonVisibility;
            set
            {
                _loginButtonVisibility = value;
                OnPropertyChanged(() => LoginButtonVisibility);
            }
        }

        private Visibility _userInfoVisibility = Visibility.Visible;
        public Visibility UserInfoVisibility
        {
            get => _userInfoVisibility;
            set
            {
                _userInfoVisibility = value;
                OnPropertyChanged(() => UserInfoVisibility);
            }
        }

        /// <summary>
        /// Доступи до запуску підпрогам
        /// </summary>
        public LauncherPermits LauncherPermits { get; set; } = new LauncherPermits();

        #endregion

        #region * * * DATA PROPERTIES * * *

        public LM_Launcher LM_Launcher { get; } = new LM_Launcher();

        private ObservableCollection<LanguageInfo> _languagesItemSource;
        /// <summary>
        /// Список наявних мов
        /// </summary>
        public ObservableCollection<LanguageInfo> LanguagesItemSource
        {
            get => _languagesItemSource;
            set
            {
                _languagesItemSource = value;
                string name = AppLanguageLibrary.ApplicationCultureInfo.Name;
                CurrentLanguage = LanguagesItemSource.FirstOrDefault(rec => rec.SpecificationCode == name);
                OnPropertyChanged(() => LanguagesItemSource);
            }
        }

        private LanguageInfo _currentLanguage;
        /// <summary>
        ///  Обрана мова серед наявних
        /// </summary>
        public LanguageInfo CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                _currentLanguage = value;
                LoadLanguage();
                OnPropertyChanged(() => CurrentLanguage);
            }
        }

        #endregion

        #region * * * METHODS * * *

        private void LoadLanguage()
        {
            try
            {
                new Task(async () => await AppLanguageLibrary.SyncOnClient()).RunSynchronously();
                AppLanguageLibrary.ChangeCurrentCulture(new CultureInfo(CurrentLanguage.SpecificationCode));
                AppLanguageLibrary.UpdateLanguageLocalization(LM_Launcher, nameof(AppLanguageLibrary.CurrentLanguage.LauncherLD));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Initialize()
        {
            if (IsInit)
                return;

            IsBusy = true;
            await Task.Factory.StartNew(async () =>
            {
                try
                {
                    var objectrightService = ObjectRightService.GetInstance();
                    IpsGlobal.SetObjectRightDictionaries(objectrightService.GetDictionary());

                    var rightholderService = new RightholderService();
                    IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());

                    var dictionary = await DictionaryService.GetInstance().GetFrameTaskDictionary(CurrentLanguage.SpecificationCode);
                    IpsGlobal.SetFrameTaskDictionary(dictionary);

                    IpsGlobal.SetMyAnketa(DictionaryService.GetInstance().GetMyAnketa());

                    IpsGlobal.Properties.Add("OwnerName", rightholderService.GetOwnerName()?.Name);

                    IsInit = true;
                }
                catch (Exception ex)
                {
                    ShowMessage.ShowError(ex.Message);
                }
            });
            IsBusy = false;
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

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            WindowUpEventCommand.Execute(null);
            
            try
            {
                var langList = AppLanguageLibrary.GetLanguagesList();
                LanguagesItemSource = new ObservableCollection<LanguageInfo>(langList);

                ShowLoginWindowCommand.Execute(null);
            }
            catch (Exception ex)
            {
                ShowMessage.ShowError(ex);
            }
        }

        public ICommand WindowUpEventCommand => new IPSDelegateCommand(WindowUpEventCommandExecute);
        private void WindowUpEventCommandExecute(object o)
        {
            CapsLockOnVisibility = Keyboard.IsKeyToggled(Key.CapsLock) ? Visibility.Visible : Visibility.Collapsed;
        }

        #region * * * відкрити модуль ... * * *

        public ICommand LoadPermitWindowCommand => new IPSDelegateCommand(LoadPermitWindowCommandExecute);
        private void LoadPermitWindowCommandExecute(object o)
        {
            FormPermitAdminConsole.Show(_authString);
        }

        public ICommand LoadCopyrightAdminWorkplaceCommand => new IPSDelegateCommand(LoadCopyrightAdminWorkplaceCommandExecute);
        private void LoadCopyrightAdminWorkplaceCommandExecute(object o)
        {
            var adminWorkplace = new CopyrightAdminWorkplaceWindow();
            //var adminWorkplace = new RightholderWorkplace.RightholderWorkplace(null);
            //UserPermissions.ImposeRestrictions(adminWorkplace);
            adminWorkplace.Show();
        }

        public ICommand LoadRoyaltyAdminCommand => new IPSDelegateCommand(LoadRoyaltyAdminCommandExecute);
        private void LoadRoyaltyAdminCommandExecute(object o)
        {
            try
            {
                var royaltyAdmin = new ReportWorkplaceWindow();
                //var royaltyAdmin = new workReport.WorkReportForm(null);
                //UserPermissions.ImposeRestrictions(royaltyAdmin);
                royaltyAdmin.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public ICommand LoadClientsSmallRightCommand => new IPSDelegateCommand(LoadConsumerSmallRightCommandExecute);
        private void LoadConsumerSmallRightCommandExecute(object o)
        {
            try
            {
                //var consumerSmallRight = new ConsumerSmallRightWorkplace.ConsumerSmallRightWorkplace();
                //UserPermissions.ImposeRestrictions(consumerSmallRight);
                //consumerSmallRight.Show();

                var clientsSR = new ClientsSRWorkplaceWindow();
                clientsSR.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public ICommand LoadConsumerBigRightCommand => new IPSDelegateCommand(LoadConsumerBigRightCommandExecute);
        private void LoadConsumerBigRightCommandExecute(object o)
        {
            try
            {
                //var consumerBigRight = new ConsumerBigRightWorkplace.ConsumerBigRightWorkplace();
                //UserPermissions.ImposeRestrictions(consumerBigRight);
                //consumerBigRight.Show();

                var clientsBR = new ClientsBRWorkplaceWindow();
                clientsBR.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public ICommand LoadRepresentCommand => new IPSDelegateCommand(LoadRepresentCommandExecute);
        private void LoadRepresentCommandExecute(object o)
        {
            try
            {
                //var partner = new PartnersWorkplace.PartnersWorkplace();
                //UserPermissions.ImposeRestrictions(partner);
                //partner.Show();

                var partner = new PartnerWorkplaceWindow();
                partner.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public ICommand LoadViolationCommand => new IPSDelegateCommand(LoadViolationCommandExecute);
        private void LoadViolationCommandExecute(object o)
        {
            try
            {
                var fixation = new Fixation.FixationForm();
                UserPermissions.ImposeRestrictions(fixation);
                fixation.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public ICommand LoadDDEXCommand => new IPSDelegateCommand(LoadDDEXCommandExecute);
        private void LoadDDEXCommandExecute(object o)
        {
            try
            {
                var ddexInvoicingForm = new DdexInvoicingForm();
                ddexInvoicingForm.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public ICommand LoadSystemDictionaryCommand => new IPSDelegateCommand(LoadSystemDictionaryCommandExecute);
        private void LoadSystemDictionaryCommandExecute(object o)
        {
            try
            {
                var dictionary = new sysAdminwp.DictionaryForm();
                UserPermissions.ImposeRestrictions(dictionary);
                dictionary.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public ICommand LoadProcessesCommand => new IPSDelegateCommand(LoadProcessesCommandExecute);
        private void LoadProcessesCommandExecute(object o)
        {
            try
            {
                var processManagment = new WorkplaceModules.ProcessManagementWorkplace.ProcessManagementWorkplaceWindow();
                processManagment.Show();

                //var fw = new FinishingWorksWorkplaceWindow();
                //fw.Show();
                //// some code
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public ICommand LoadAnalyticsCommand => new IPSDelegateCommand(LoadAnalyticsCommandExecute);
        private void LoadAnalyticsCommandExecute(object o)
        {
            try
            {
                var reports = new RepNew.Аналітика();
                reports.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public ICommand LoadOurProfileCommand => new IPSDelegateCommand(LoadOurProfileCommandExecute);
        private void LoadOurProfileCommandExecute(object o)
        {
            try
            {
                // some code
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion

        public ICommand SAAuthCommand => new IPSDelegateCommand(SAAuthCommandExecute);
        private void SAAuthCommandExecute(object o)
        {
            Initialize();

            LauncherPermits.RightsAdmin = true;
            LauncherPermits.RoyaltyAdmin = true;
            LauncherPermits.SRightsWp = true;
            LauncherPermits.BRightsWp = true;
            LauncherPermits.Represent = true;
            LauncherPermits.Violation = true;
            LauncherPermits.Directory = true;
            //LauncherPermits.Permit = true;
            LauncherPermits.Processes = true;
            LauncherPermits.Analytics = true;
            LauncherPermits.OurProfile = true;
            LauncherPermits.Ddex = true;

            UserInfo.UserName = "sys.admin";
            UserInfo.Name = "sys.admin";
            IsSignIn = true;
        }

        #endregion


        #region LOGIN MODAL WINDOW

        #region * * * BEHAVIOR PROPERTIES * * *

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

        private Visibility _modalWindowVisibility = Visibility.Collapsed;
        public Visibility ModalWindowVisibility
        {
            get => _modalWindowVisibility;
            set
            {
                _modalWindowVisibility = value;
                OnPropertyChanged(() => ModalWindowVisibility);
            }
        }

        private Visibility _newPasswordVisibility = Visibility.Collapsed;
        public Visibility NewPasswordVisibility
        {
            get => _newPasswordVisibility;
            set
            {
                _newPasswordVisibility = value;
                OnPropertyChanged(() => NewPasswordVisibility);
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
                OnPropertyChanged(() => Remember);
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
            UserInfo.Name = identity.Name;
            UserInfo.UserName = identity.Name;
            UserInfo.UserRole = "Default User";

            window.DialogResult = true;
            window.Close();
        }

        private void AuthorizationThroughServerAccount()
        {
            IsBusy = true;
            PermitApiProxy.UserLogin = User.UserName;
            PermitApiProxy.UserPassword = User.PlainPassword;
            PermitApiProxy.BaseUri = GetPermitUri();

            //if (NewPasswordVisible != Visibility.Visible)
            {
                RspLogin response = PermitApiProxy.Login();
                IsBusy = false;
                if (response.Result == RspLogin.LoginResult.Success)
                {
                    User.CodeI = response.UserCodeI;

                    UserInfo.UserName = User.UserName;
                    UserInfo.Name = response.Name;

                    ModalWindowVisibility = Visibility.Collapsed;
                    Authorize();

                }
                else if (response.Result == RspLogin.LoginResult.Failed)
                {
                    MessageBox.Show("Invalid login and/or password. Please, change and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (response.Result == RspLogin.LoginResult.ChangePassword)
                {
                    MessageBox.Show("Please, change password", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    //PasswordVisible = Visibility.Collapsed;
                    //NewPasswordVisible = Visibility.Visible;
                    return;
                }
            }
            //else
            //{
            //    if (!User.PlainNewPassword.Equals(User.PlainConfirmPassword))
            //    {
            //        IsBusy = false;
            //        MessageBox.Show("Input passwords are not the same. Please, change and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }
            //    if (!IsPasswordStrong(User.PlainNewPassword))
            //    {
            //        IsBusy = false;
            //        MessageBox.Show("Password is not strong enough. Please. make sure that it is not less than 8 characters in length and contains digits, letters in lower and upper cases, and at least one special character.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }
            //    RspLogin res = PermitApiProxy.ChangePasswordAndLogin(User.UserName, User.PlainPassword, User.PlainNewPassword);
            //    if (res.Result == RspLogin.LoginResult.Failed)
            //    {
            //        IsBusy = false;
            //        MessageBox.Show("Invalid login and/or password. Please, change and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }
            //    IsBusy = false;
            //    User.CodeI = res.UserCodeI;
            //    User.Password = User.NewPassword;
            //    ModalWindowVisibility = Visibility.Collapsed;
            //    Authorize();
            //}
        }

        private void Authorize()
        {
            try
            {
                _authString = User.AuthString;
                string baseUri = GetPermitUri();
                UserPermissions.Load(baseUri, User.CodeI);

                LauncherPermits.RightsAdmin = UserPermissions.CanRead("RHObjects");
                LauncherPermits.RoyaltyAdmin = UserPermissions.CanRead("ReportIdent");
                LauncherPermits.SRightsWp = UserPermissions.CanRead("Consum(SR)");
                LauncherPermits.BRightsWp = UserPermissions.CanRead("Consum(BR)");
                LauncherPermits.Represent = UserPermissions.CanRead("Represent");
                LauncherPermits.Violation = UserPermissions.CanRead("Violation");
                LauncherPermits.Directory = UserPermissions.CanRead("Directory");
                LauncherPermits.Permit = UserPermissions.CanRead("Permit");
                LauncherPermits.Processes = UserPermissions.CanRead("Processes");
                LauncherPermits.Analytics = UserPermissions.CanRead("Analytics");
                LauncherPermits.OurProfile = UserPermissions.CanRead("OurProfile");
                LauncherPermits.Ddex = UserPermissions.CanRead("Ddex");

                IsSignIn = true;

                Initialize();
            }
            catch (Exception ex)
            {
                ShowMessage.ShowError(ex);
            }
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
                //User.NewPassword = window.newPwBox.SecurePassword;
                //User.ConfirmPassword = window.confirmPwBox.SecurePassword;
                passwordBox.Clear();
                AuthorizationThroughServerAccount();
            }
            catch (Exception e)
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
            var pbValid = (o as PasswordBox)?.Password.Length >= 8;

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

            var key = (KeyEventArgs)o;
            if (key.Key == Key.Enter)
            {
                if (!(((KeyEventArgs)o).Source is PasswordBox passwordBox))
                    return;

                if (LoginCommand.CanExecute(passwordBox))
                    LoginCommand.Execute(passwordBox);
            }
        }

        public ICommand ShowLoginWindowCommand => new IPSDelegateCommand(ShowLoginWindowCommandExecute);
        private void ShowLoginWindowCommandExecute(object o)
        {
            ModalWindowVisibility = Visibility.Visible;
        }

        public ICommand HideLoginWindowCommand => new IPSDelegateCommand(HideLoginWindowCommandExecute);
        private void HideLoginWindowCommandExecute(object o)
        {
            ModalWindowVisibility = Visibility.Collapsed;
        }

        public ICommand LogOutCommand => new IPSDelegateCommand(LogOutCommandExecute);
        private void LogOutCommandExecute(object o)
        {
            LauncherPermits.RightsAdmin = false;
            LauncherPermits.RoyaltyAdmin = false;
            LauncherPermits.SRightsWp = false;
            LauncherPermits.BRightsWp = false;
            LauncherPermits.Represent = false;
            LauncherPermits.Violation = false;
            LauncherPermits.Directory = false;
            LauncherPermits.Permit = false;
            LauncherPermits.Processes = false;
            LauncherPermits.Analytics = false;
            LauncherPermits.OurProfile = false;
            LauncherPermits.Ddex = false;

            UserInfo = new UserInfoModel();
            IsSignIn = false;
        }

        #endregion

        #endregion
    }
}
