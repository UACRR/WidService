using LanguageLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LanguageLibrary;
using Telerik.Windows.Controls;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Launcher.Controls.LoginWindow;
using Launcher.General.Model;
using SmRoPermitAdmin;
using System.Runtime.InteropServices;
using System.Configuration;
using ipsFormsDesign.Data;
using ipsFormsDesign.Services;
using Launcher.WorkplaceModules.CopyrightAdminWorkplace;
using System.IO;
using Launcher.WorkplaceModules.ClientsBRWorkplace;
using Launcher.WorkplaceModules.ClientsSRWorkplace;
using Launcher.WorkplaceModules.ReportWorkplace;
using SmRoPermitClientLib;

namespace Launcher.General
{
    public class LauncherViewModel : ViewModelBase
    {
        private string _authString;
        public LauncherViewModel()
        {
            UserInfoVisibility = Visibility.Collapsed;
        }

        #region * * * BEHAVIOR PROPERTIES * * *

        private bool _isSignIn;
        public bool IsSignIn
        {
            get => _isSignIn;
            set
            {
                _isSignIn = value;
                LoginButtonVisibility = Visibility.Collapsed;
                UserInfoVisibility = Visibility.Visible;
                OnPropertyChanged(() => IsSignIn);
            }
        }

        private string _userName = "...";
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(() => UserName);
            }
        }

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

        private Visibility _contentVisibility = Visibility.Visible;
        public Visibility ContentVisibility
        {
            get => _contentVisibility;
            set
            {
                _contentVisibility = value;
                OnPropertyChanged(() => ContentVisibility);
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
                
                if (ContentVisibility == Visibility.Hidden)
                    ContentVisibility = Visibility.Visible;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task Initialize()
        {
            try
            {
                var _rightholderService = new RightholderService();

                var objectrightService = new ObjectRightService();
                IpsGlobal.SetObjectRightDictionaries(objectrightService.GetDictionary());

                var rightholderService = new RightholderService();
                IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());

                var dictionary = await DictionaryService.GetInstance().GetFrameTaskDictionary(CurrentLanguage.SpecificationCode);
                IpsGlobal.SetFrameTaskDictionary(dictionary);

                IpsGlobal.Properties.Add("OwnerName", _rightholderService.GetOwnerName()?.Name);
            }
            catch(Exception ex)
            {
                ShowMessage.ShowError(ex.Message);
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

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            try
            {
                ContentVisibility = Visibility.Hidden;
                var langList = AppLanguageLibrary.GetLanguagesList();
                LanguagesItemSource = new ObservableCollection<LanguageInfo>(langList);
                LoginCommand.Execute(null);
                ContentVisibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                ShowMessage.ShowError(ex.Message);
                return;
            }
        }

        public ICommand LoginCommand => new IPSDelegateCommand(LoginCommandExecute);
        private async void LoginCommandExecute(object o)
        {
            try
            {
                LoginWindow loginWindow = new LoginWindow();
                bool result = loginWindow.ShowDialog() ?? false;
                if (result)
                {
                    var user = ((LoginViewModel)loginWindow.DataContext).User;

                    UserName = user.UserName;
                    IsSignIn = true;

                    _authString = user.AuthString;
                    string baseUri = GetPermitUri();
                    UserPermissions.Load(baseUri, user.CodeI);
                    //SmRoPermitClientLib.UserPermissions.Load(ConfigurationManager.AppSettings["SmRoPermitApiBaseUri"], user.CodeI);

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

                    await Initialize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

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
                var partner = new PartnersWorkplace.PartnersWorkplace();
                UserPermissions.ImposeRestrictions(partner);
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
                // some code
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

        public ICommand SAAuthCommand => new IPSDelegateCommand(SAAuthCommandExecute);
        private async void SAAuthCommandExecute(object o)
        {
            LauncherPermits.RightsAdmin = true;
            LauncherPermits.RoyaltyAdmin = true;
            LauncherPermits.SRightsWp = true;
            LauncherPermits.BRightsWp = true;
            LauncherPermits.Represent = true;
            LauncherPermits.Violation = true;
            LauncherPermits.Directory = true;
            LauncherPermits.Permit = true;
            LauncherPermits.Processes = true;
            LauncherPermits.Analytics = true;
            LauncherPermits.OurProfile = true;

            await Initialize();
        }

        #endregion
    }
}
