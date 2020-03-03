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

        /// <summary>
        /// Доступи до запуску підпрогам
        /// </summary>
        public LauncherPermits LauncherPermits { get; set; } = new LauncherPermits();

        #endregion

        #region * * * DATA PROPERTIES * * *

        public LM_Launcher LM_Launcher { get; } = new LM_Launcher();

        private ObservableCollection<LanguageInfo> _languagesItemSource = new ObservableCollection<LanguageInfo>
        {
            new LanguageInfo
            {
                SpecificationCode = "uk-UA",
                LanguageName = "Ukrainian",
            },
            new LanguageInfo
            {
                SpecificationCode = "en-US",
                LanguageName = "English",
            },
            new LanguageInfo
            {
                SpecificationCode = "ru-RU",
                LanguageName = "Russian",
            },
            new LanguageInfo
            {
                SpecificationCode = "es-ES",
                LanguageName = "Spanish",
            },
        };
        /// <summary>
        /// Список наявних мов
        /// </summary>
        public ObservableCollection<LanguageInfo> LanguagesItemSource
        {
            get => _languagesItemSource;
            set
            {
                _languagesItemSource = value;
                string name = AppLanguageLibrary.CurrentAppCultureInfo.Name;
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
            await AppLanguageLibrary.SyncOnClient();
            AppLanguageLibrary.ChangeCurrentCulture(new CultureInfo(CurrentLanguage.SpecificationCode));
            LM_Launcher.UpdateLanguageLocalization();
        }

        private async void Initialize()
        {
            var _rightholderService = new RightholderService();

            var objectrightService = new ObjectRightService();
            IpsGlobal.SetObjectRightDictionaries(objectrightService.GetDictionary());

            var rightholderService = new RightholderService();
            IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());

            IpsGlobal.Properties.Add("OwnerName", _rightholderService.GetOwnerName()?.Name);

        }
        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private async void LoadCommandExecute(object o)
        {
            LanguagesItemSource = new ObservableCollection<LanguageInfo>(AppLanguageLibrary.GetLanguagesList());
            await Task.Delay(1500);
            LoginCommandExecute(null);
            Initialize();
        }

        public ICommand LoginCommand => new IPSDelegateCommand(LoginCommandExecute);
        private void LoginCommandExecute(object o)
        {
            LoginWindow loginWindow = new LoginWindow();
            bool result = loginWindow.ShowDialog() ?? false;
            if (result)
            {
                var user = ((LoginViewModel)loginWindow.DataContext).User;

                UserName = user.UserName;
                IsSignIn = true;

                _authString = user.AuthString;
                SmRoPermitClientLib.UserPermissions.Load(ConfigurationManager.AppSettings["SmRoPermitApiBaseUri"], user.CodeI);

                LauncherPermits.RightsAdmin = SmRoPermitClientLib.UserPermissions.CanRead("RightsAdmin");
                LauncherPermits.RoyaltyAdmin = SmRoPermitClientLib.UserPermissions.CanRead("RoyaltyAdmin");
                LauncherPermits.SRightsWp = SmRoPermitClientLib.UserPermissions.CanRead("SRightsWp");
                LauncherPermits.BRightsWp = SmRoPermitClientLib.UserPermissions.CanRead("BRightsWp");
                LauncherPermits.PRAdmin = SmRoPermitClientLib.UserPermissions.CanRead("PRAdmin");
                LauncherPermits.Violation = SmRoPermitClientLib.UserPermissions.CanRead("Violation");
                LauncherPermits.Directory = SmRoPermitClientLib.UserPermissions.CanRead("Directory");
                LauncherPermits.UserAdmin = SmRoPermitClientLib.UserPermissions.CanRead("UserAdmin");
            }
        }

        public ICommand LoadPermitWindowCommand => new IPSDelegateCommand(LoadPermitWindowCommandExecute);
        private void LoadPermitWindowCommandExecute(object o)
        {
            FormPermitAdminConsole form = new FormPermitAdminConsole(_authString);
            form.Show();
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
