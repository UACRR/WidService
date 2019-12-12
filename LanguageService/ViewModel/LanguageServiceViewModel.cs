using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using ipsFormsDesign.Services;
using LanguageLibrary;
using LanguageLibrary.Model;
using LanguageService.Model;
using Telerik.Windows.Controls;
using IPSDelegateCommand = LanguageService.Extensions.IPSDelegateCommand;
using LanguageDataModel = LanguageLibrary.Model.LanguageDataModel;

namespace LanguageService.ViewModel
{
    public class LanguageServiceViewModel : ViewModelBase
    {
        public LanguageServiceViewModel()
        {

        }

        #region * * * BEHAVIOR PROPERTIES * * *

        private XmlLanguage _language;
        public XmlLanguage Language
        {
            get
            {
                if (_language == null)
                    return XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);

                return _language;
            }
            set
            {
                _language = value;
                OnPropertyChanged(() => Language);
            }
        }

        private Visibility _editPanelVisibility = Visibility.Collapsed;
        /// <summary>
        /// Видимість панелі редагування
        /// </summary>
        public Visibility EditPanelVisibility
        {
            get => _editPanelVisibility;
            set
            {
                _editPanelVisibility = value;
                OnPropertyChanged(() => EditPanelVisibility);
            }
        }

        private Visibility _categoryPanelVisibility = Visibility.Visible;
        /// <summary>
        /// Видимість панелі категорії 
        /// </summary>
        public Visibility CategoryPanelVisibility
        {
            get => _categoryPanelVisibility;
            set
            {
                _categoryPanelVisibility = value;
                OnPropertyChanged(() => CategoryPanelVisibility);
            }
        }

        #endregion

        #region * * * DATA PROPERTIES * * *

        private LanguageCompletenessModel _currentLanguageCompleteness = new LanguageCompletenessModel
        {
            AllCategoryCountItems = 0,
            AllCategoryIncompletenessCountItems = 0,
        };
        public LanguageCompletenessModel CurrentLanguageCompleteness
        {
            get => _currentLanguageCompleteness;
            set
            {
                _currentLanguageCompleteness = value;
                OnPropertyChanged(() => CurrentLanguageCompleteness);
            }
        }

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
                OnPropertyChanged(() => LanguagesItemSource);
                CurrentLanguage = LanguagesItemSource.FirstOrDefault();
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
                UpdateLanguageByCurrent();
                OnPropertyChanged(() => CurrentLanguage);
            }
        }

        private ObservableCollection<LanguageInfo> _possibleLanguagesItemSource;
        /// <summary>
        /// Список мов які можна створити
        /// </summary>
        public ObservableCollection<LanguageInfo> PossibleLanguagesItemSource
        {
            get => _possibleLanguagesItemSource;
            set
            {
                _possibleLanguagesItemSource = value;
                OnPropertyChanged(() => PossibleLanguagesItemSource);
            }
        }

        private LanguageInfo _currentPossibleLanguage;
        /// <summary>
        /// Обрана мова для створення
        /// </summary>
        public LanguageInfo CurrentPossibleLanguage
        {
            get => _currentPossibleLanguage;
            set
            {
                _currentPossibleLanguage = value;
                OnPropertyChanged(() => CurrentPossibleLanguage);
            }
        }

        #endregion

        #region * * * METHODS * * *

        private void UpdateLanguageByCurrent()
        {
            List<LanguageDataModel> data = ApplicationLanguageLibrary.GetLanguageData(CurrentLanguage);
            
            CurrentLanguageCompleteness.AllCategoryCountItems = data.Count;
            CurrentLanguageCompleteness.AllCategoryIncompletenessCountItems = data.Count(rec => string.IsNullOrEmpty(rec.Content));
            
            CurrentLanguageCompleteness.ButtonsCategoryCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.Buttons);
            CurrentLanguageCompleteness.ButtonsCategoryIncompletenessCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.Buttons
                                                                                            && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.StaticTextCategoryCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.StaticText);
            CurrentLanguageCompleteness.StaticTextCategoryIncompletenessCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.StaticText
                                                                                               && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.ColumnCategoryCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.Column);
            CurrentLanguageCompleteness.ColumnCategoryIncompletenessCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.Column
                                                                                           && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.MenuAndTabCategoryCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.MenuAndTab);
            CurrentLanguageCompleteness.MenuAndTabCategoryIncompletenessCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.MenuAndTab
                                                                                               && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.SystemMessagesCategoryCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.SystemMessages);
            CurrentLanguageCompleteness.SystemMessagesCategoryIncompletenessCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.SystemMessages
                                                                                                   && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.ToolTipTextCategoryCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.ToolTipText);
            CurrentLanguageCompleteness.ToolTipTextCategoryIncompletenessCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.ToolTipText
                                                                                                && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.OtherCategoryCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.Other);
            CurrentLanguageCompleteness.OtherCategoryIncompletenessCount = data.Count(rec => rec.ComponentCategory == ComponentCategory.Other
                                                                                          && string.IsNullOrEmpty(rec.Content));
        }

        #endregion

        #region * * * COMMANDS * * *

        /// <summary>
        /// Завантажити дані
        /// </summary>
        public ICommand LoadLanguagesListCommand => new IPSDelegateCommand(LoadLanguagesListCommandExecute);
        private void LoadLanguagesListCommandExecute(object o)
        {
            var languageList = ApplicationLanguageLibrary.GetLanguagesList();
            LanguagesItemSource = new ObservableCollection<LanguageInfo>(languageList);
            
            var list = ApplicationLanguageLibrary.GetPossibleLanguageList();
            PossibleLanguagesItemSource = new ObservableCollection<LanguageInfo>(list);
        }

        /// <summary>
        /// Створити нову мову
        /// </summary>
        public ICommand CreateNewLanguageCommand => new IPSDelegateCommand(CreateNewLanguageCommandExecute);
        private void CreateNewLanguageCommandExecute(object o)
        {

        }

        /// <summary>
        /// Зберегти зміни
        /// </summary>
        public ICommand SaveItemChangeCommand => new IPSDelegateCommand(SaveItemChangeCommandExecute);
        private void SaveItemChangeCommandExecute(object o)
        {

        }

        /// <summary>
        /// Перейти на наступний елемент
        /// </summary>
        public ICommand MoveToNextItemCommand => new IPSDelegateCommand(MoveToNextItemCommandExecute);
        private void MoveToNextItemCommandExecute(object o)
        {

        }

        /// <summary>
        /// Перейти на попередній елемент
        /// </summary>
        public ICommand MoveToPreviousItemCommand => new IPSDelegateCommand(MoveToPreviousItemCommandExecute);
        private void MoveToPreviousItemCommandExecute(object o)
        {

        }

        /// <summary>
        /// Повернутись до розділу категорій
        /// </summary>
        public ICommand BackToCategoryCommand => new IPSDelegateCommand(BackToCategoryCommandExecute);
        private void BackToCategoryCommandExecute(object o)
        {
            EditPanelVisibility = Visibility.Collapsed;
            CategoryPanelVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Всі елементи по обраній мові
        /// </summary>
        public ICommand AllCategoryCommand => new IPSDelegateCommand(AllCategoryCommandExecute);
        private void AllCategoryCommandExecute(object o)
        {
            EditPanelVisibility = Visibility.Visible;
            CategoryPanelVisibility = Visibility.Collapsed;

            //var data = ApplicationLanguageLibrary.GetLanguageData(new LanguageInfo{ SpecificationCode = "ru-RU"});
            //ApplicationLanguageLibrary.Sync();

            //ApplicationLanguageLibrary.CreateLanguage(new LanguageInfo
            //{
            //    SpecificationCode = "ru-RU",
            //    IncompletenessItemCount = 2000,
            //    LanguageName = "Русский",
            //    UkrainianName = "Російська",
            //});
        }

        /// <summary>
        /// Незавповнені по обраній мові
        /// </summary>
        public ICommand IncompletenessCategoryCommand => new IPSDelegateCommand(IncompletenessCategoryCommandExecute);
        private void IncompletenessCategoryCommandExecute(object o)
        {

        }

        #endregion

    }
}
