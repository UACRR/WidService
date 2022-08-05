using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using LanguageLibrary;
using LanguageService.Extensions;
using Telerik.Windows.Controls;

namespace LanguageService.Controls.CreateLanguage
{
    public class CreateLanguageViewModel : ViewModelBase
    {
        #region * * * PROPERTIES * * *

        private ObservableCollection<CreateLanguageModel> _languageModelItemSource;
        public ObservableCollection<CreateLanguageModel> LanguageModelItemSource
        {
            get => _languageModelItemSource;
            set
            {
                _languageModelItemSource = value;
                OnPropertyChanged(() => LanguageModelItemSource);
            }
        }

        private CreateLanguageModel _selectedLanguage;
        /// <summary>
        /// Обрана мова
        /// </summary>
        public CreateLanguageModel SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged(() => SelectedLanguage);
            }
        }

        #endregion

        #region * * * COMMANDS * * * 

        public ICommand LoadWindowCommand => new IPSDelegateCommand(LoadWindowCommandExecute);
        private void LoadWindowCommandExecute(object o)
        {
            var languages = new ObservableCollection<CreateLanguageModel>();
            var list = LanguageLibraryManager.GetPossibleLanguageList();
            foreach (var languageInfo in list)
            {
                var language = new CreateLanguageModel
                {
                    SpecificationCode = languageInfo.SpecificationCode,
                    LanguageName = $"{languageInfo.LanguageName} ({languageInfo.UkrainianName})",
                    LanguageInfo = languageInfo,
                };
                languages.Add(language);
            }

            LanguageModelItemSource = languages;
        }

        public ICommand CreateNewLanguageCommand => new IPSDelegateCommand(CreateNewLanguageCommandExecute);
        private void CreateNewLanguageCommandExecute(object o)
        {
            if (SelectedLanguage == null)
                return;

            LanguageLibraryManager.CreateLanguage(SelectedLanguage.LanguageInfo);
            if (o is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        public ICommand CloseWindowCommand => new IPSDelegateCommand(CloseWindowCommandExecute);
        private void CloseWindowCommandExecute(object o)
        {
            if (o is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }

        #endregion
    }
}
