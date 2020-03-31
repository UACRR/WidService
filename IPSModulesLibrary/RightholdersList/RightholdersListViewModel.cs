using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.RightholderControls;
using IPSViewComponentLibraryWPF.Controls.SearchControl;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.Windows.Controls;
using DTC = IPSViewComponentLibraryWPF.Extensions.DataTableConverter;

namespace IPSModulesLibrary.RightholdersList
{
    public class RightholdersListViewModel : ViewModelBase, ILazyLoadData
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
                Header = "Всі правовласники",
                IsExpanded = true,
                IsSelectable = false,
                FontWeight = FontWeights.SemiBold,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                ItemsSource = new ObservableCollection<RadTreeViewItem>
                {
                    new RadTreeViewItem
                    {
                        Header = "Всі",
                        FontWeight = FontWeights.Normal,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                }
            },
            new RadTreeViewItem
            {
                Header = "Правовласники УААСП",
                IsExpanded = true,
                IsSelectable = false,
                FontWeight = FontWeights.SemiBold,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                ItemsSource = new ObservableCollection<RadTreeViewItem>
                {
                    new RadTreeViewItem
                    {
                        Name = "all_internal",
                        Header = "Всі",
                        FontWeight = FontWeights.Normal,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "no_accepted",
                        Header = "Не підтверджені",
                        FontWeight = FontWeights.Normal,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "on_accepted",
                        Header = "На акцепті",
                        FontWeight = FontWeights.Normal,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "active",
                        Header = "Активний",
                        IsSelected = true,
                        FontWeight = FontWeights.Normal,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "closed",
                        Header = "Закритий",
                        FontWeight = FontWeights.Normal,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "heritage",
                        Header = "Оформлення спадщини",
                        FontWeight = FontWeights.Normal,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },
                    new RadTreeViewItem
                    {
                        Name = "blocked",
                        Header = "Заблокований",
                        FontWeight = FontWeights.Normal,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    },

                }
            },
            new RadTreeViewItem
            {
                Header = "Зовнішні правовласники",
                IsExpanded = true,
                IsSelectable = false,
                FontWeight = FontWeights.SemiBold,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                ItemsSource = new ObservableCollection<RadTreeViewItem>
                {
                    new RadTreeViewItem
                    {
                        Name = "all_external",
                        Header = "Всі",
                        FontWeight = FontWeights.Normal,
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

                string name = _selectedTreeViewItem.Name;
                using (var task = Task.Factory.StartNew(() => FilterList(name)))
                {
                    IsBusy = true;   
                    task.Wait();
                    IsBusy = false;
                }
            }
        }

        private DataTable TempDataTable { get; set; }
        private ICollection<RightholdersListModel> ObjectsRightsItemSourceTemp { get; set; }
        private ICollection<RightholdersListModel> _objectsRightsItemSource;
        public ICollection<RightholdersListModel> ObjectsRightsItemSource
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

            var task = LoadData(new ObjectRightSearchResource());
            IsDataLoaded = true;
        }

        private async Task LoadData(ObjectRightSearchResource searchResource)
        {
            var service = new RightholderService();
            
            IsBusy = true;
            var data = await service.GetRightholdersList(searchResource);

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

        private List<RightholdersListModel> ConvertToInternalModel(DataTable dataTable)
        {
            var itemSource = new List<RightholdersListModel>();

            var DTH = new DataTableHelper(dataTable.Columns);

            foreach (DataRow row in dataTable.Rows)
            {
                var obj = row.ItemArray;

                var item = new RightholdersListModel
                {
                    CustId = DTC.CastInt(DTH.GetObject(obj, nameof(RightholdersListModel.CustId))),
                    CustStatus = DTC.CastShort(DTH.GetObject(obj, nameof(RightholdersListModel.CustStatus))),
                    CustType = DTC.CastShort(DTH.GetObject(obj, nameof(RightholdersListModel.CustType))),
                    AgrStatus = DTC.CastShortNull(DTH.GetObject(obj, nameof(RightholdersListModel.AgrStatus))),
                    InnerCode = DTC.Cast<string>(DTH.GetObject(obj, nameof(RightholdersListModel.InnerCode))),
                    InterCode= DTC.Cast<string>(DTH.GetObject(obj, nameof(RightholdersListModel.InterCode))),
                    Name = DTC.Cast<string>(DTH.GetObject(obj, nameof(RightholdersListModel.Name))),
                    AgreementDate = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(RightholdersListModel.AgreementDate))),
                    CntObj = DTC.CastInt(DTH.GetObject(obj, nameof(RightholdersListModel.CntObj))),
                    YearProfit = DTC.CastFloat(DTH.GetObject(obj, nameof(RightholdersListModel.YearProfit))),
                    RHolderType = DTC.CastShort(DTH.GetObject(obj, nameof(RightholdersListModel.RHolderType))),
                };

                itemSource.Add(item);
            }

            return itemSource;
        }


        private void FilterList(string filterName)
        {
            if (ObjectsRightsItemSourceTemp == null)
                return;

            if (!string.IsNullOrEmpty(filterName))
            {
                IEnumerable<RightholdersListModel> list = null;
                filterName = filterName.ToUpper();

                if (filterName.ToUpper() == "active".ToUpper())
                    list = ObjectsRightsItemSourceTemp.Where(rec => rec.AgrStatus == 2);

                ObjectsRightsItemSource = list?.ToList();
            }
            else
            {
                ObjectsRightsItemSource = ObjectsRightsItemSourceTemp.ToList();
            }
        }

        private async void RunSearchDelegateMethod(ObjectRightSearchResource searchResource)
        {
            // wrap
            await LoadData(searchResource);
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
        private void LoadCommandExecute(object o)
        {
            if (IsLoaded)
                return;


#if DEBUG

            //var rightholderService = new RightholderService();
            //IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());

            //var searchControl = ((RightholdersListControl)o).searchControl;

            //var t = Task.Factory.StartNew(async () =>
            //{
            //    var dictionary = await DictionaryService.GetInstance().GetFrameTaskDictionary("uk-UA");
            //    IpsGlobal.SetFrameTaskDictionary(dictionary);
            //    // debug
            //    var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 2).FrameParam;
            //    ((SearchControlViewModel)searchControl.DataContext).Config = config;
            //});
            //t.Wait();

#endif

            var searchControl = ((RightholdersListControl)o).searchControl;
            var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 2).FrameParam;
            ((SearchControlViewModel)searchControl.DataContext).Config = config;
            ((SearchControlViewModel)searchControl.DataContext).RunSearchQuery = RunSearchDelegateMethod;
            ((SearchControlViewModel)searchControl.DataContext).Clear = Clear;

            IsLoaded = true;

            var task = LoadData(new ObjectRightSearchResource());
        }

        public ICommand OpenRightholderCommand => new IPSDelegateCommand(OpenRightholderCommandExecute);
        public void OpenRightholderCommandExecute(object o)
        {
            var item = (RightholdersListModel) o;
            using (var rightholderView = new RightholderView())
            {
                var rightholderPresenter = new RightholderPresenter(rightholderView);
                rightholderPresenter.Show(item.CustId);
            }
        }

        /// <summary>
        /// Додати зовнішнього правовласника
        /// </summary>
        public ICommand CreateRHExternalPhisCommand => new IPSDelegateCommand(CreateRhExternalPhisCommandExecute);
        private void CreateRhExternalPhisCommandExecute(object o)
        {
            CreateNewRightholderExternal(1);
        }

        /// <summary>
        /// Додати зовнішнього правовласника (видавництво)
        /// </summary>
        public ICommand CreateRHExternalPubCommand => new IPSDelegateCommand(CreateRHExternalPubCommandExecute);
        private void CreateRHExternalPubCommandExecute(object o)
        {
            CreateNewRightholderExternal(3);
        }

        private void CreateNewRightholderExternal(int rhType)
        {
            var service = new RightholderService();

            var customer = service.NewExternalRightholder(rhType);
            using (var externalRightHolderForm = new NewRightholderExternalForm())
            {
                externalRightHolderForm.LoadData(customer);
                if (externalRightHolderForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var result = service.SaveRightholderExternal(customer);
                    ShowMessage.ShowInfoByResult(SaveNewRightholderExternalSuccessMsg, SaveNewRightholderExternalErrorMsg, result);
                }
            }
        }

        private const string SaveNewRightholderExternalSuccessMsg = "Нового зовнішнього правовласника/видавництво додано!";
        private const string SaveNewRightholderExternalErrorMsg = "Неможливо додати нового зовнішнього правовласника/видавництво!";

        public ICommand CreateRHPhisCommand => new IPSDelegateCommand(CreateRhPhisCommandExecute);
        private void CreateRhPhisCommandExecute(object o)
        {
            CreateNewRightholder(1);
        }

        public ICommand CreateRHJurCommand => new IPSDelegateCommand(CreateRhJurCommandExecute);
        private void CreateRhJurCommandExecute(object o)
        {
            CreateNewRightholder(3);
        }

        private static void CreateNewRightholder(int custType)
        {
            using (var rightholderView = new NewRightholderView())
            {
                var rightholderPresenter = new RightholderPresenter(rightholderView);
                rightholderPresenter.ShowNew(custType);
            }
        }

        #endregion
    }
}
