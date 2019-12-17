using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using LanguageService.Controls.CreateLanguage;
using LanguageService.Model;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using IPSDelegateCommand = LanguageService.Extensions.IPSDelegateCommand;
using LanguageDataModel = LanguageLibrary.Model.LanguageDataModel;

namespace LanguageService.ViewModel
{
    public class LanguageServiceViewModel : ViewModelBase
    {
        private bool _someValueChanged = false;
        private List<LanguageDataModel> _languageDataModel;
        private readonly Dictionary<string, ComponentCategory> _componentCategories = new Dictionary<string, ComponentCategory>
        {
            ["buttons"] = ComponentCategory.Buttons,
            ["staticText"] = ComponentCategory.StaticText,
            ["column"] = ComponentCategory.Column,
            ["menuAndTab"] = ComponentCategory.MenuAndTab,
            ["systemMessages"] = ComponentCategory.SystemMessages,
            ["toolTipText"] = ComponentCategory.ToolTipText,
            ["other"] = ComponentCategory.Other,
        };

        public LanguageServiceViewModel() { }

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

        private LanguageCompletenessModel _currentLanguageCompleteness = new LanguageCompletenessModel();
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
                CurrentLanguage = LanguagesItemSource.FirstOrDefault();
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
                LoadCurrentLanguageLocalization();
                BackToCategoryCommand.Execute(null);
                OnPropertyChanged(() => CurrentLanguage);
            }
        }

        private ObservableCollection<LanguageDataModel> _languageDataModelItemSource;
        /// <summary>
        /// Список елементів обраної мови
        /// </summary>
        public ObservableCollection<LanguageDataModel> LanguageDataModelItemSource
        {
            get => _languageDataModelItemSource;
            set
            {
                _languageDataModelItemSource = value;
                OnPropertyChanged(() => LanguageDataModelItemSource);
            }
        }

        private LanguageDataModel _currentLanguageDataModel = new LanguageDataModel
        {
            DefaultContent = "Confirm",
            PropertyName = "confirm_btn",
            Description = "Button of main page",
        };
        /// <summary>
        /// Конкретний обраний елемент
        /// </summary>
        public LanguageDataModel CurrentLanguageDataModel
        {
            get => _currentLanguageDataModel;
            set
            {
                _currentLanguageDataModel = value;
                EditedLanguageDataModel = new LanguageDataModel
                {
                    Content = value?.Content,
                    Description = value?.Description,
                    DefaultContent = value?.DefaultContent,
                    PropertyName = value?.PropertyName,
                    ContainerName = value?.ContainerName,
                };
                OnPropertyChanged(() => CurrentLanguageDataModel);
            }
        }

        private LanguageDataModel _editedLanguageDataModel;
        /// <summary>
        /// Об'єкт редагування
        /// </summary>
        public LanguageDataModel EditedLanguageDataModel
        {
            get => _editedLanguageDataModel;
            set
            {
                _editedLanguageDataModel = value;
                OnPropertyChanged(() => EditedLanguageDataModel);
            }
        }

        #endregion

        #region * * * METHODS * * *

        /// <summary>
        /// Завантажити дані відображення після зміни мови
        /// </summary>
        private void LoadCurrentLanguageLocalization()
        {
            _languageDataModel = ApplicationLanguageLibrary.GetLanguageData(CurrentLanguage);
            
            CurrentLanguageCompleteness.AllCategoryCountItems = _languageDataModel.Count;
            CurrentLanguageCompleteness.AllCategoryIncompletenessCountItems = _languageDataModel.Count(rec => string.IsNullOrEmpty(rec.Content));
            
            CurrentLanguageCompleteness.ButtonsCategoryCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.Buttons);
            CurrentLanguageCompleteness.ButtonsCategoryIncompletenessCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.Buttons
                                                                                            && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.StaticTextCategoryCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.StaticText);
            CurrentLanguageCompleteness.StaticTextCategoryIncompletenessCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.StaticText
                                                                                               && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.ColumnCategoryCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.Column);
            CurrentLanguageCompleteness.ColumnCategoryIncompletenessCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.Column
                                                                                           && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.MenuAndTabCategoryCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.MenuAndTab);
            CurrentLanguageCompleteness.MenuAndTabCategoryIncompletenessCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.MenuAndTab
                                                                                               && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.SystemMessagesCategoryCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.SystemMessages);
            CurrentLanguageCompleteness.SystemMessagesCategoryIncompletenessCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.SystemMessages
                                                                                                   && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.ToolTipTextCategoryCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.ToolTipText);
            CurrentLanguageCompleteness.ToolTipTextCategoryIncompletenessCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.ToolTipText
                                                                                                && string.IsNullOrEmpty(rec.Content));

            CurrentLanguageCompleteness.OtherCategoryCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.Other);
            CurrentLanguageCompleteness.OtherCategoryIncompletenessCount = _languageDataModel.Count(rec => rec.ComponentCategory == ComponentCategory.Other
                                                                                          && string.IsNullOrEmpty(rec.Content));
        }

        #endregion

        #region * * * COMMANDS * * *

        /// <summary>
        /// Завантажити список наявних мовних конфігурацій
        /// </summary>
        public ICommand LoadLanguagesListCommand => new IPSDelegateCommand(LoadLanguagesListCommandExecute);
        private void LoadLanguagesListCommandExecute(object o)
        {
            var languageList = ApplicationLanguageLibrary.GetLanguagesList();
            LanguagesItemSource = new ObservableCollection<LanguageInfo>(languageList);
        }

        /// <summary>
        /// Синхронізувати дані об'єкта моделі да XML документів
        /// </summary>
        public ICommand SyncLanguagesDataCommand => new IPSDelegateCommand(SyncLanguagesDataCommandExecute);
        private void SyncLanguagesDataCommandExecute(object o)
        {
            ApplicationLanguageLibrary.Sync();
            MessageBox.Show("Файли локалізацій успішно синхронізовано з об'єктом локалізації!", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Створити нову мову
        /// </summary>
        public ICommand CreateNewLanguageCommand => new IPSDelegateCommand(CreateNewLanguageCommandExecute);
        private void CreateNewLanguageCommandExecute(object o)
        {
            var window = new CreateLanguageWindow();
            var result = window.ShowDialog() ?? false;
            
            if (result)
            {
                var languageList = ApplicationLanguageLibrary.GetLanguagesList();
                LanguagesItemSource = new ObservableCollection<LanguageInfo>(languageList);
                MessageBox.Show("Нову мовну локалізацію створено!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                _someValueChanged = true;
            }
        }

        /// <summary>
        /// Зберегти зміни редагованого елемента
        /// </summary>
        public ICommand SaveItemChangeCommand => new IPSDelegateCommand(SaveItemChangeCommandExecute);
        private void SaveItemChangeCommandExecute(object o)
        {
            CurrentLanguageDataModel.Content = EditedLanguageDataModel.Content;
            ApplicationLanguageLibrary.UpdateLanguageData(CurrentLanguage, EditedLanguageDataModel);
            MoveToNextItemCommand.Execute(null);
            _someValueChanged = true;
        }

        /// <summary>
        /// Перейти на наступний елемент
        /// </summary>
        public ICommand MoveToNextItemCommand => new IPSDelegateCommand(MoveToNextItemCommandExecute);
        private void MoveToNextItemCommandExecute(object o)
        {
            int index = LanguageDataModelItemSource.IndexOf(CurrentLanguageDataModel);
            if (index == -1 || index == LanguageDataModelItemSource.Count - 1)
                return;

            index++;
            CurrentLanguageDataModel = LanguageDataModelItemSource[index];
        }

        /// <summary>
        /// Перейти на попередній елемент
        /// </summary>
        public ICommand MoveToPreviousItemCommand => new IPSDelegateCommand(MoveToPreviousItemCommandExecute);
        private void MoveToPreviousItemCommandExecute(object o)
        {
            int index = LanguageDataModelItemSource.IndexOf(CurrentLanguageDataModel);
            
            if (index == -1 || index == 0)
                return;

            index--;
            CurrentLanguageDataModel = LanguageDataModelItemSource[index];
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
        /// Показати елементи категорії по обраній мові
        /// </summary>
        public ICommand SelectCategoryCommand => new IPSDelegateCommand(SelectCategoryCommandExecute);
        private void SelectCategoryCommandExecute(object o)
        {
            string categoryName = o as string;
            if (string.IsNullOrEmpty(categoryName))
                return;

            if (categoryName == "all")
            {
                LanguageDataModelItemSource = new ObservableCollection<LanguageDataModel>(_languageDataModel);

            }
            else if (_componentCategories.ContainsKey(categoryName))
            {
                var data = _languageDataModel.Where(rec => rec.ComponentCategory == _componentCategories[categoryName]).ToList();
                LanguageDataModelItemSource = new ObservableCollection<LanguageDataModel>(data);
            }
            else
            {
                return;
            }

            EditPanelVisibility = Visibility.Visible;
            CategoryPanelVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Синхронізація з сервером при виході з програми
        /// </summary>
        public ICommand SyncOnServerWhenClosingCommand => new IPSDelegateCommand(SyncOnServerWhenClosingCommandExecute);
        private async void SyncOnServerWhenClosingCommandExecute(object o)
        {
            if (!_someValueChanged)
                return;

            var result = await ApplicationLanguageLibrary.SyncOnServer();
            if (!result.IsSuccess)
                MessageBox.Show("Помилка синхронізації з сервером!", result.InnerMessage, MessageBoxButton.OK,MessageBoxImage.Warning);
        }

        #endregion

        public ICommand TestCommand => new IPSDelegateCommand(TestCommandExecute);
        private async void TestCommandExecute(object o)
        {
            //var result1 = await ApplicationLanguageLibrary.SyncOnServer();
            
            //await ApplicationLanguageLibrary.SyncOnClient();
        }
    }
}
