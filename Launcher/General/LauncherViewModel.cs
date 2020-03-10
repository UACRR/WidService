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
        //    = new ObservableCollection<LanguageInfo>
        //{
        //    new LanguageInfo
        //    {
        //        SpecificationCode = "uk-UA",
        //        LanguageName = "Ukrainian",
        //    },
        //    new LanguageInfo
        //    {
        //        SpecificationCode = "en-US",
        //        LanguageName = "English",
        //    },
        //    new LanguageInfo
        //    {
        //        SpecificationCode = "ru-RU",
        //        LanguageName = "Russian",
        //    },
        //    new LanguageInfo
        //    {
        //        SpecificationCode = "es-ES",
        //        LanguageName = "Spanish",
        //    },
        //};
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

        private async void LoadLanguage()
        {
            try
            {
                await AppLanguageLibrary.SyncOnClient();
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
                LanguagesItemSource = new ObservableCollection<LanguageInfo>(AppLanguageLibrary.GetLanguagesList());
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
                    SmRoPermitClientLib.UserPermissions.Load(baseUri, user.CodeI);
                    //SmRoPermitClientLib.UserPermissions.Load(ConfigurationManager.AppSettings["SmRoPermitApiBaseUri"], user.CodeI);

                    LauncherPermits.RightsAdmin = SmRoPermitClientLib.UserPermissions.CanRead("RightsAdmin");
                    LauncherPermits.RoyaltyAdmin = SmRoPermitClientLib.UserPermissions.CanRead("RoyaltyAdmin");
                    LauncherPermits.SRightsWp = SmRoPermitClientLib.UserPermissions.CanRead("SRightsWp");
                    LauncherPermits.BRightsWp = SmRoPermitClientLib.UserPermissions.CanRead("BRightsWp");
                    LauncherPermits.PRAdmin = SmRoPermitClientLib.UserPermissions.CanRead("PRAdmin");
                    LauncherPermits.Violation = SmRoPermitClientLib.UserPermissions.CanRead("Violation");
                    LauncherPermits.Directory = SmRoPermitClientLib.UserPermissions.CanRead("Directory");
                    LauncherPermits.Permit = SmRoPermitClientLib.UserPermissions.CanRead("Permit");

                    await Initialize();
                }
                else
                    ShowMessage.ShowWarning("Login attempt cancelled by user");
                
                //throw new Exception("Login attempt cancelled by user");
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
            adminWorkplace.Show();
        }

        #endregion
    }
}
