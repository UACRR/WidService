using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data;
using System.Globalization;
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
using LanguageLibrary;
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

        private bool IsReloadData { get; set; }

        private ObservableCollection<RadTreeViewItem> _treeViewItemSource;
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
                    task.Wait();
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

        private LM_RightholdersList _loc = new LM_RightholdersList();
        public LM_RightholdersList LOC
        {
            get => _loc;
            set
            {
                _loc = value;
                OnPropertyChanged(() => LOC);
            }
        }

        #endregion

        #region * * * METHODS * * *

        public void LazyLoadData()
        {
            if (IsDataLoaded)
                return;

            var task = LoadData(new SearchModuleResource());
            IsDataLoaded = true;
        }

        private async Task LoadData(SearchModuleResource searchModuleResource)
        {
            var service = new RightholderService();
            
            IsBusy = true;
            var data = await service.GetRightholdersList(searchModuleResource);

            if (data.IsSuccess)
            {
                if (TempDataTable == null || IsReloadData)
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

            // reload complete
            if (IsReloadData)
                IsReloadData = false;

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

                switch (filterName)
                {
                    case "all_internal":
                        list = ObjectsRightsItemSourceTemp.Where(rec => rec.CustType != 5);
                        break;
                    case "no_accepted":
                        list = ObjectsRightsItemSourceTemp.Where(rec => rec.CustType != 5 && rec.AgrStatus == 0);
                        break;
                    case "on_accepted":
                        list = ObjectsRightsItemSourceTemp.Where(rec => rec.CustType != 5 && (rec.AgrStatus == 1 || rec.AgrStatus == 3));
                        break;
                    case "active":
                        list = ObjectsRightsItemSourceTemp.Where(rec => rec.CustType != 5 && rec.AgrStatus == 2);
                        break;
                    case "closed":
                        list = ObjectsRightsItemSourceTemp.Where(rec => rec.CustType != 5 && rec.AgrStatus == 4);
                        break;
                    case "heritage":
                        list = ObjectsRightsItemSourceTemp.Where(rec => rec.CustType != 5 && rec.AgrStatus == 7);
                        break;
                    case "blocked":
                        list = ObjectsRightsItemSourceTemp.Where(rec => rec.CustType != 5 && rec.AgrStatus == 8);
                        break;

                    case "all_external":
                        list = ObjectsRightsItemSourceTemp.Where(rec => rec.CustType == 5);
                        break;

                }

                ObjectsRightsItemSource = list?.ToList();
            }
            else
            {
                ObjectsRightsItemSource = ObjectsRightsItemSourceTemp.ToList();
            }
        }

        private async void RunSearchDelegateMethod(SearchModuleResource searchModuleResource)
        {
            // wrap
            await LoadData(searchModuleResource);
        }

        private async void Clear()
        {
            IsBusy = true;
            ObjectsRightsItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(TempDataTable));
            string name = SelectedTreeViewItem.Name;
            await Task.Factory.StartNew(() => FilterList(name));
            IsBusy = false;
        }

        private void GenerateTreeViewItems()
        {
            TreeViewItemSource = new ObservableCollection<RadTreeViewItem>
            {
                new RadTreeViewItem
                {
                    //Header = "Всі правовласники",
                    Header = LOC.TV_CAT_ALL_RH,
                    IsExpanded = true,
                    IsSelectable = false,
                    FontWeight = FontWeights.SemiBold,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    ItemsSource = new ObservableCollection<RadTreeViewItem>
                    {
                        new RadTreeViewItem
                        {
                            //Header = "Всі",
                            Header = LOC.TV_ALL,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },
                    }
                },
                new RadTreeViewItem
                {
                    //Header = "Правовласники ОКУ",
                    Header = LOC.TV_CAT_OCM_RH,
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
                            //Header = "Всі",
                            Header = LOC.TV_ALL,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },
                        new RadTreeViewItem
                        {
                            Name = "no_accepted",
                            //Header = "Не підтверджені",
                            Header = LOC.TV_NO_ACCEPTED,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },
                        new RadTreeViewItem
                        {
                            Name = "on_accepted",
                            //Header = "На акцепті",
                            Header = LOC.TV_ON_ACCEPTED,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },
                        new RadTreeViewItem
                        {
                            Name = "active",
                            //Header = "Активний",
                            Header = LOC.TV_ACTIVE,
                            IsSelected = true,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },
                        new RadTreeViewItem
                        {
                            Name = "closed",
                            //Header = "Закритий",
                            Header = LOC.TV_CLOSED,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },
                        new RadTreeViewItem
                        {
                            Name = "heritage",
                            //Header = "Оформлення спадщини",
                            Header = LOC.TV_HERITAGE,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },
                        new RadTreeViewItem
                        {
                            Name = "blocked",
                            //Header = "Заблокований",
                            Header = LOC.TV_BLOCKED,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },

                    }
                },
                new RadTreeViewItem
                {
                    //Header = "Зовнішні правовласники",
                    Header = LOC.TV_CAT_EXTERNAL_RH,
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
                            //Header = "Всі",
                            Header = LOC.TV_ALL,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },
                    }
                },
            };
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            if (IsLoaded)
                return;

            var searchControl = ((RightholdersListControl)o).searchControl;
            var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 2).FrameParam;
            ((SearchControlViewModel)searchControl.DataContext).Config = config;
            ((SearchControlViewModel)searchControl.DataContext).RunSearchQuery = RunSearchDelegateMethod;
            ((SearchControlViewModel)searchControl.DataContext).Clear = Clear;

            AppLanguageLibrary.UpdateLanguageLocalization(LOC, nameof(AppLanguageLibrary.CurrentLanguage.RightholdersListLD));
            GenerateTreeViewItems();

            IsLoaded = true;
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
                    ShowMessage.ShowInfoByResult(LOC.CREATE_RH_EXT_SUCC_MSG, LOC.CREATE_RH_EXT_ERR_MSG, result);
                }
            }
        }

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

        /// <summary>
        /// Оновити дані
        /// </summary>
        public ICommand UpdateDataCommand => new IPSDelegateCommand(UpdateDataCommandExecute);
        private async void UpdateDataCommandExecute(object o)
        {
            IsReloadData = true;
            await LoadData(new SearchModuleResource());
        }

        #endregion
    }
}
