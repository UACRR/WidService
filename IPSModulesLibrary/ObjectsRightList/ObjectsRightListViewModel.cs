using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using IpsCommonTypes.Types;
using ipsFormsDesign.Data;
using IPSViewComponentLibraryWPF.Controls.SearchControl;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.Windows.Controls;

namespace IPSModulesLibrary.ObjectsRightList
{
    public class ObjectsRightListViewModel : ViewModelBase
    {
        #region * * * PROPERTIES * * *

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(() => IsBusy);
            }
        }

        private ObservableCollection<RadTreeViewItem> _treeViewItemSource = new ObservableCollection<RadTreeViewItem>
        {
            new RadTreeViewItem
            {
                Header = "Стан",
                IsExpanded = true,
                IsSelectable = false,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                ItemsSource = new ObservableCollection<RadTreeViewItem>
                {
                    new RadTreeViewItem
                    {
                        Name = "all",
                        Header = "Всі",
                        IsSelected = true,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "notAccept",
                        Header = "Не підтверджені",
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "notAttach",
                        Header = "Не прив'язані",
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "notDistributed",
                        Header = "Не розподілені",
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                }
            },
        };
        public ObservableCollection<RadTreeViewItem> TreeViewItemSource
        {
            get => _treeViewItemSource;
            set
            {
                _treeViewItemSource = value;
                OnPropertyChanged(() => TreeViewItemSource);
            }
        }

        private RadTreeViewItem _selectedTreeViewItem;
        public RadTreeViewItem SelectedTreeViewItem
        {
            get => _selectedTreeViewItem;
            set
            {
                _selectedTreeViewItem = value;
                OnPropertyChanged(() => SelectedTreeViewItem);
            }
        }

        #endregion

        #region * * * METHODS * * *

        private void RunSearchDelegateMethod(object o)
        {
            if (typeof(SearchData).IsEquivalentTo(o.GetType()))
                ;
            else if (o.GetType().GetInterface(nameof(ICollection<SearchDataExtended>)) != null)
                ;
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private async void LoadCommandExecute(object o)
        {
            var searchControl = ((ObjectsRightListControl) o).searchControl;
            var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 1).FrameParam;
            ((SearchControlViewModel) searchControl.DataContext).LoadConfiguration(config);
            ((SearchControlViewModel) searchControl.DataContext).RunSearchQuery = RunSearchDelegateMethod;

            var rnd = new Random().Next(1000, 3500);
            IsBusy = true;
            await Task.Delay(rnd);
            IsBusy = false;
        }

        #endregion
    }
}
