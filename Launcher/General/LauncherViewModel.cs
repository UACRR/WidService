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

namespace Launcher.General
{
    public class LauncherViewModel : ViewModelBase
    {
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

        private void LoadLanguage()
        {
            Task.Factory.StartNew(async () => await AppLanguageLibrary.SyncOnClient()).Wait();
            AppLanguageLibrary.ChangeCurrentCulture(new CultureInfo(CurrentLanguage.SpecificationCode));
            LM_Launcher.UpdateLanguageLocalization();
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private async void LoadCommandExecute(object o)
        {
            LanguagesItemSource = new ObservableCollection<LanguageInfo>(AppLanguageLibrary.GetLanguagesList());
            await Task.Delay(1500);
            LoginCommandExecute(null);
        }

        public ICommand LoginCommand => new IPSDelegateCommand(LoginCommandExecute);
        private void LoginCommandExecute(object o)
        {
            LoginWindow loginWindow = new LoginWindow();
            bool result = loginWindow.ShowDialog() ?? false;
            if (result)
            {
                var userInfo =((LoginViewModel) loginWindow.DataContext).UserInfo;
                UserName = userInfo.UserName;
                IsSignIn = true;
            }
        }

        #endregion
    }
}
