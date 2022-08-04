using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;
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
using Launcher.Controls;
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
            try
            {
                var langList = AppLanguageLibrary.GetLanguagesList();
                LanguagesItemSource = new ObservableCollection<LanguageInfo>(langList);

                SignInCommand.Execute(null);
            }
            catch (Exception ex)
            {
                ShowMessage.ShowError(ex);
            }
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
            try
            {
                var adminWorkplace = new CopyrightAdminWorkplaceWindow();
                adminWorkplace.Show();
            }
            catch (Exception ex)
            {
                ShowMessage.ShowError(ex.ToString());
            }
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
                ShowMessage.ShowError(e.ToString());
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
                ShowMessage.ShowError(e.ToString());
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
                ShowMessage.ShowError(e.ToString());
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
                ShowMessage.ShowError(e.ToString());
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
                ShowMessage.ShowError(e.ToString());
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
                ShowMessage.ShowError(e.ToString());
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
                ShowMessage.ShowError(e.ToString());
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
                ShowMessage.ShowError(e.ToString());
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
                ShowMessage.ShowError(e.ToString());
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
                ShowMessage.ShowError(e.ToString());
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

            User.UserName = "sys.admin";
            User.Name = "sys.admin";
            IsSignIn = true;
        }

        #endregion


        #region LOGIN MODAL WINDOW

        #region * * * BEHAVIOR PROPERTIES * * *

        private Visibility _loginWindowVisibility = Visibility.Collapsed;
        public Visibility LoginWindowVisibility
        {
            get => _loginWindowVisibility;
            set
            {
                _loginWindowVisibility = value;
                OnPropertyChanged(() => LoginWindowVisibility);
            }
        }

        #endregion

        #region * * * DATA PROPERTIES * * *

        private UserModel _user = new UserModel();
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

        public ICommand SignInCommand => new IPSDelegateCommand(SignInCommandExecute);
        private void SignInCommandExecute(object o)
        {
            LoginWindowVisibility = Visibility.Visible;
            LoginWindow2 loginWindow = new LoginWindow2(User);
            loginWindow.Owner = Application.Current.MainWindow;
            var result = loginWindow.ShowDialog();
            if (result ?? false)
            {
                Authorize();
            }
            LoginWindowVisibility = Visibility.Collapsed;
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

            User = new UserModel();
            IsSignIn = false;
        }

        public ICommand ChangePasswordCommand => new IPSDelegateCommand(ChangePasswordCommandExecute);
        private void ChangePasswordCommandExecute(object o)
        {
            ChangePassword changePassword = new ChangePassword(User, false);
            changePassword.ShowDialog();
        }

        #endregion

        #endregion
    }
}
