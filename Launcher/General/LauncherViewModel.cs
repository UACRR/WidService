using LanguageLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LanguageLibrary;
using Telerik.Windows.Controls;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Launcher.General.Model;

namespace Launcher.General
{
    public class LauncherViewModel : ViewModelBase
    {
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
            LM_Launcher.UpdateLanguageLocalizations();
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            LanguagesItemSource = new ObservableCollection<LanguageInfo>(AppLanguageLibrary.GetLanguagesList());
        }

        #endregion
    }
}
