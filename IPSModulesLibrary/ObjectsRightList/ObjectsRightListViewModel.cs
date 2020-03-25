using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using IpsCommonTypes.ClassesForSearchQuery;
using IpsCommonTypes.Types;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using IPSModulesLibrary.ObjectsRightList.Model;
using IpsViewComponentLibrary.ObjectRightControls;
using IPSViewComponentLibraryWPF.Controls.SearchControl;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.Windows.Controls;
using DTC = IPSViewComponentLibraryWPF.Extensions.DataTableConverter;

namespace IPSModulesLibrary.ObjectsRightList
{
    public class ObjectsRightListViewModel : ViewModelBase, ILazyLoadData
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

        public bool IsLoaded { get; set; }
        private bool IsDataLoaded { get; set; }

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
                        Header = "Всі",
                        IsSelected = true,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "statusNoActive",
                        Header = "Не підтверджені",
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "statusNoRelate",
                        Header = "Не прив'язані",
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "statusUnDistrib",
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
                
                string name = _selectedTreeViewItem.Name;
                Task.Factory.StartNew(() => FilterList(name));
                OnPropertyChanged(() => SelectedTreeViewItem);
            }
        }

        private DataTable TempDataTable { get; set; }
        private ICollection<ObjectsRightListModel> ObjectsRightsItemSourceTemp { get; set; }
        private ICollection<ObjectsRightListModel> _objectsRightsItemSource;
        public ICollection<ObjectsRightListModel> ObjectsRightsItemSource
        {
            get => _objectsRightsItemSource;
            set
            {
                _objectsRightsItemSource = value;
                OnPropertyChanged(() => ObjectsRightsItemSource);
            }
        }

        #endregion

        #region * * * METHODS * * *

        public void LazyLoadData()
        {
            if (IsDataLoaded)
                return;

            LoadData(new ObjectRightSearchResource());
            IsDataLoaded = true;
        }

        private async Task LoadData(ObjectRightSearchResource searchResource)
        {
            var service = new ObjectRightService();
            IsBusy = true;
            var data = await service.GetObjectRightListAsync(searchResource);

            if (data.IsSuccess)
            {
                if (TempDataTable == null)
                    TempDataTable = data.Data;
                
                ObjectsRightsItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(data.Data));
                string name = SelectedTreeViewItem.Name;
                await Task.Factory.StartNew(() => FilterList(name));
            }
            else
            {
                // todo : add handler for returned Exception
                ShowMessage.ShowError(data.Exception?.Message);
            }

            IsBusy = false;

            GC.Collect();
        }

        private void FilterList(string filterName)
        {
            if (ObjectsRightsItemSourceTemp == null)
                return;

            if (!string.IsNullOrEmpty(filterName))
            {
                IEnumerable<ObjectsRightListModel> list = null;
                filterName = filterName.ToUpper();

                if (filterName == nameof(ObjectsRightListModel.StatusNoRelate).ToUpper())
                    list = ObjectsRightsItemSourceTemp.Where(rec => rec.StatusNoRelate == 1);

                if (filterName == nameof(ObjectsRightListModel.StatusNoActive).ToUpper())
                    list = ObjectsRightsItemSourceTemp.Where(rec => rec.StatusNoActive == 1);

                if (filterName == nameof(ObjectsRightListModel.StatusUnDistrib).ToUpper())
                    list = ObjectsRightsItemSourceTemp.Where(rec => rec.StatusUnDistrib == 1);

                ObjectsRightsItemSource = list?.ToList();
            }
            else
            {
                ObjectsRightsItemSource = ObjectsRightsItemSourceTemp.ToList();
            }
        }

        private async void RunSearchDelegateMethod(object o)
        {
            var searchResource = new ObjectRightSearchResource();

            if (typeof(SearchData).IsEquivalentTo(o.GetType()))
            {
                searchResource.SimpleSearch = (SearchData)o;
            }
            else if (o.GetType().GetInterface(nameof(ICollection<SearchDataExtended>)) != null)
            {
                searchResource.MultiplySearch = new List<SearchDataExtended>((ICollection<SearchDataExtended>)o);
            }

            await LoadData(searchResource);
        }

        private List<ObjectsRightListModel> ConvertToInternalModel(DataTable dataTable)
        {
            var itemSource = new List<ObjectsRightListModel>();
            
            var d_TO = getColumnDictionary(dataTable.Columns);
            
            foreach (DataRow row in dataTable.Rows)
            {
                var obj = row.ItemArray;

                var item = new ObjectsRightListModel
                {
                    ObjId = DTC.CastInt(getObject(obj, nameof(ObjectsRightListModel.ObjId))),
                    ISWC = DTC.Cast<string>(getObject(obj, nameof(ObjectsRightListModel.ISWC))),
                    CategoryCode = DTC.CastInt(getObject(obj, nameof(ObjectsRightListModel.CategoryCode))),
                    GenreType = DTC.CastIntNull(getObject(obj, nameof(ObjectsRightListModel.GenreType))),
                    Name = DTC.Cast<string>(getObject(obj, nameof(ObjectsRightListModel.Name))),
                    RateTotal = DTC.CastFloat(getObject(obj, nameof(ObjectsRightListModel.RateTotal))),

                    Author = DTC.Cast<string>(getObject(obj, nameof(ObjectsRightListModel.Author))),
                    Performer = DTC.Cast<string>(getObject(obj, nameof(ObjectsRightListModel.Performer))),
                    InnerCode = DTC.Cast<string>(getObject(obj, nameof(ObjectsRightListModel.InnerCode))),

                    StatusNoActive = DTC.CastByte(getObject(obj, nameof(ObjectsRightListModel.StatusNoActive))),
                    StatusNoRelate = DTC.CastByte(getObject(obj, nameof(ObjectsRightListModel.StatusNoRelate))),
                    StatusUnDistrib = DTC.CastByte(getObject(obj, nameof(ObjectsRightListModel.StatusUnDistrib))),
                };

                itemSource.Add(item);
            }

            Dictionary<string, int> getColumnDictionary(DataColumnCollection columns)
            {
                var temp = new Dictionary<string, int>();

                for (int i = 0; i < columns.Count; i++)
                {
                    temp.Add(columns[i].ColumnName.ToLower(), i);
                }

                return temp;
            }

            object getObject(object[] obj, string fieldName)
            {
                if (!d_TO.ContainsKey(fieldName.ToLower()))
                    return null;
                
                return obj[d_TO[fieldName.ToLower()]];
            }

            return itemSource;
        }

        private async void Clear()
        {
            IsBusy = true;
            ObjectsRightsItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(TempDataTable));
            string name = SelectedTreeViewItem.Name;
            await Task.Factory.StartNew(() => FilterList(name));
            IsBusy = false;
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private async void LoadCommandExecute(object o)
        {
            if (IsLoaded)
                return;

            var searchControl = ((ObjectsRightListControl) o).searchControl;
            var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 1).FrameParam;
            ((SearchControlViewModel)searchControl.DataContext).Config = config;
            ((SearchControlViewModel) searchControl.DataContext).RunSearchQuery = RunSearchDelegateMethod;
            ((SearchControlViewModel) searchControl.DataContext).Clear = Clear;

            //var search = new ObjectRightSearchResource();
            IsLoaded = true;
            //await LoadData(search);
        }

        public ICommand OpenObjectRightCommand => new IPSDelegateCommand(OpenObjectRightCommandExecute);
        private void OpenObjectRightCommandExecute(object o)
        {
            var objectRight = (ObjectsRightListModel) o;
            // CategoryCode == 5 - малі права
            if (objectRight.CategoryCode == 5)
            {
                using (var view = new ObjectRightSrView())
                {
                    var presenter = new ObjectRightSrPresenter(view);
                    presenter.Show(objectRight.ObjId);
                }
            }
            else
            {
                using (var view = new ObjectRightBrView())
                {
                    var presenter = new ObjectRightBrPresenter(view);
                    presenter.Show(objectRight.ObjId);
                }
            }
        }

        public ICommand CreateObjectRightCommand => new IPSDelegateCommand(CreateObjectRightCommandExecute);
        private void CreateObjectRightCommandExecute(object o)
        {
            using (var view = new ObjectRightSrView())
            {
                var presenter = new ObjectRightSrPresenter(view);
                presenter.DefaultRightholder = null;
                presenter.ShowNew(5);
            }
        }

        #endregion
    }
}
