using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using IpsCommonTypes.Enums;
using IpsCommonTypes.Types;
using ipsFormsDesign.Model;
using IPSViewComponentLibraryWPF.Controls.SearchControl.Model;
using IPSViewComponentLibraryWPF.IPSExtensions;
using LanguageLibrary;
using Telerik.Windows.Controls;
using Label = System.Windows.Controls.Label;

namespace IPSViewComponentLibraryWPF.Controls.SearchControl
{
    public class SearchControlViewModel : ViewModelBase
    {
        private const string FullValue = "Full";
        private const string PartValue = "Part";

        #region * * * PROPERTIES * * *

        private ObservableCollection<CheckBox> _listBoxItemsSource = new ObservableCollection<CheckBox>();
        /// <summary>
        /// Елементи для звичайного пошуку
        /// </summary>
        public ObservableCollection<CheckBox> ListBoxItemsSource
        {
            get => _listBoxItemsSource;
            set
            {
                _listBoxItemsSource = value;
                OnPropertyChanged(() => ListBoxItemsSource);
            }
        }

        private ObservableCollection<StackPanel> _listBoxExtendedItemsSource = new ObservableCollection<StackPanel>();
        /// <summary>
        /// Елементи для розширеного пошуку
        /// </summary>
        public ObservableCollection<StackPanel> ListBoxExtendedItemsSource
        {
            get => _listBoxExtendedItemsSource;
            set
            {
                _listBoxExtendedItemsSource = value;
                OnPropertyChanged(() => ListBoxExtendedItemsSource);
            }
        }

        private SimpleSearchParameters _simpleSearchParameters = new SimpleSearchParameters();
        public SimpleSearchParameters SimpleSearchParameters
        {
            get => _simpleSearchParameters;
            set
            {
                _simpleSearchParameters = value;
                OnPropertyChanged(() => SimpleSearchParameters);
            }
        }

        public Action<object> RunSearchQuery { get; set; }

        public LM_SEARCH LM_SEARCH { get; set; } = new LM_SEARCH();

        #endregion

        #region * * * _PRIVATE_ METHODS * * *

        private CheckBox CreateCheckBox(SearchItem searchItem)
        {
            var item = new CheckBox
            {
                Name = searchItem.KeyField,
                Content = searchItem.NameField,
                Margin = new Thickness(3, 3, 3, 3),
            };
            if (searchItem.KeyField == "ALL")
            {
                item.Checked += (o, e) =>
                {
                    foreach (var checkBox in ListBoxItemsSource)
                        checkBox.IsChecked = true;

                };
                item.Unchecked += (o, e) =>
                {
                    foreach (var checkBox in ListBoxItemsSource)
                        checkBox.IsChecked = false;
                };
            }


            return item;
        }

        private StackPanel CreateExtendedItem(SearchItem searchItem)
        {
            var item = new StackPanel
            {
                Name = searchItem.KeyField,
                Orientation = Orientation.Horizontal,
                Background = new SolidColorBrush(Color.FromArgb(255, 240, 248, 255)),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Children =
                {
                    new TextBox
                    {
                        Name = searchItem.KeyField,
                        Width = 250,
                        Margin = new Thickness(3,3,3,3)
                    },
                    new Label
                    {
                        Content = searchItem.NameField,
                        MinWidth = 175,
                        IsTabStop = false,
                    },
                    new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Children =
                        {
                            new RadioButton
                            {
                                Name = FullValue,
                                //Content = "Точне значення",
                                Content = LM_SEARCH.EQ_VAL,
                                IsChecked = true,
                                VerticalContentAlignment = VerticalAlignment.Center,
                                Margin = new Thickness(5,3,3,3),
                                IsTabStop = false,
                            },
                            new RadioButton
                            {
                                Name = PartValue,
                                //Content = "Містить текст",
                                Content = LM_SEARCH.LIKE_VAL,
                                VerticalContentAlignment = VerticalAlignment.Center,
                                Margin = new Thickness(5,3,3,3),
                                IsTabStop = false,
                            },
                        }
                    }
                }
            };

            return item;
        }

        #endregion

        #region * * * _PUBLIC_ METHOD * * *

        public void LoadConfiguration(ICollection<FrameParam> config)
        {
            var list = new List<SearchItem>
            {
                new SearchItem("ALL", LM_SEARCH.ALL_CHECK_ITEM),
            };

            foreach (var frameParam in config)
            {
                list.Add(new SearchItem(frameParam.SeekCodeName, frameParam.SeekName));
            }

            foreach (var searchItem in list)
                ListBoxItemsSource.Add(CreateCheckBox(searchItem));

            foreach (var searchItem in list.Where(rec => rec.KeyField != "ALL").ToList())
                ListBoxExtendedItemsSource.Add(CreateExtendedItem(searchItem));
        }

        #endregion

        #region * * * COMMANDS * * *

        /// <summary>
        /// запустити простий пошук
        /// </summary>
        public ICommand RunSearchCommand => new IPSDelegateCommand(RunSearchCommandExecute);
        private void RunSearchCommandExecute(object serachText)
        {
            var propertyList = new List<string>();
            foreach (var checkBox in ListBoxItemsSource)
            {
                if ((checkBox.IsChecked ?? false) && checkBox.Name != "ALL")
                    propertyList.Add(checkBox.Name);
            }

            if(string.IsNullOrEmpty(SimpleSearchParameters.SearchText))
            {
                ShowMessage.ShowWarning("Не введено пошукове слово!");
                return;
            }

            if (!propertyList.Any())
            {
                ShowMessage.ShowWarning("Не обрано жодного поля для пошуку!");
                return;
            }

            var searchData = new SearchData
            {
                SearchText = SimpleSearchParameters.SearchText,
                MatchTextOfSearch = SimpleSearchParameters.MatchTextOfSearch,
                SearchParametersValue = propertyList,
            };

            // exec search
            RunSearchQuery?.Invoke(searchData);
        }

        /// <summary>
        /// запустити простий пошук
        /// </summary>
        public ICommand RunSearchExtendedCommand => new IPSDelegateCommand(RunSearchExtendedCommandExecute);
        private void RunSearchExtendedCommandExecute(object o)
        {
            var propertyList = new List<SearchDataExtended>();

            foreach (var stackPanel in ListBoxExtendedItemsSource)
            {
                var txt = (TextBox)stackPanel.Children[0];

                if (string.IsNullOrWhiteSpace(txt.Text))
                    continue;

                MatchTextOfSearch getMatchType()
                { 
                    var isFullValue = ((RadioButton)((StackPanel)stackPanel.Children[2]).Children[0]).IsChecked ?? false;
                    var isPartValue = ((RadioButton)((StackPanel)stackPanel.Children[2]).Children[1]).IsChecked ?? false;

                    if (isFullValue)
                        return MatchTextOfSearch.Equal;
                    if (isPartValue)
                        return MatchTextOfSearch.Like;

                    throw new ArgumentOutOfRangeException();
                }

                propertyList.Add(new SearchDataExtended
                {
                    SearchParameterValue = txt.Name,
                    SearchText = txt.Text,
                    MatchTextOfSearch = getMatchType()
                });
            }

            if (!propertyList.Any())
            {
                ShowMessage.ShowWarning("Відсутні дані для пошуку!");
                return;
            }

            // exec search
            RunSearchQuery?.Invoke(propertyList);
        }

        public ICommand LoadedCommand => new IPSDelegateCommand(LoadedCommandExecute);
        private void LoadedCommandExecute(object o)
        {
            AppLanguageLibrary.UpdateLanguageLocalization(LM_SEARCH, nameof(AppLanguageLibrary.CurrentLanguage.SearchControlLD));
        }

        #endregion
    }
}
