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
using LanguageLibrary;
using LanguageLibrary.Model;
using LanguageService.Model;
using Telerik.Windows.Controls;
using IPSDelegateCommand = LanguageService.Extensions.IPSDelegateCommand;

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

        private ObservableCollection<NavigationItemModel> _languagesItemsSource = new ObservableCollection<NavigationItemModel>
        {
            new NavigationItemModel
            {
                Title = "English",
                IconPath = @"..\Images\united-kingdom.png"
            },
            new NavigationItemModel
            {
                Title = "Ураїнська",
                IconPath = @"..\Images\ukraine.png"
            },
            new NavigationItemModel
            {
                Title = "Русский",
                IconPath = @"..\Images\russia.png"
            },
        };
        public ObservableCollection<NavigationItemModel> LanguagesItemsSource
        {
            get => _languagesItemsSource;
            set
            {
                _languagesItemsSource = value;
                OnPropertyChanged(() => LanguagesItemsSource);
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

        private LanguageCompletenessModel _currentLanguageCompleteness;
        public LanguageCompletenessModel CurrentLanguageCompleteness
        {
            get => _currentLanguageCompleteness;
            set
            {
                _currentLanguageCompleteness = value;
                OnPropertyChanged(() => CurrentLanguageCompleteness);
            }
        }

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
                OnPropertyChanged(() => LanguagesItemSource);
            }
        }

        private LanguageInfo _currentLanguage;
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
            var data = ApplicationLanguageLibrary.GetLanguageData(CurrentLanguage);
            // handle this

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

        public ICommand MoveToNextItemCommand => new IPSDelegateCommand(MoveToNextItemCommandExecute);
        private void MoveToNextItemCommandExecute(object o)
        {

        }

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
