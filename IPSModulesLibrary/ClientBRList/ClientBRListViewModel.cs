using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsFormsDesign.Data;
using ipsFormsDesign.Services;
using IPSModulesLibrary.ClientSRList;
using IPSViewComponentLibraryWPF.Controls.SearchControl;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.Windows.Controls;

namespace IPSModulesLibrary.ClientBRList
{
    public class ClientBRListViewModel : IPSViewModel<LM_ClientBRList>
    {
        public ClientBRListViewModel()
        {
            LazyLoadDataAction = async () => await LoadData();
        }

        #region * * * PROPERTIES * * *

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

                string name = _selectedTreeViewItem.Name;
                Task.Factory.StartNew(() => FilterList(name));
                OnPropertyChanged(() => SelectedTreeViewItem);
            }
        }

        private ICollection<ClientBRListModel> ClientsBRItemSourceTemp { get; set; }
        private ICollection<ClientBRListModel> _clientsBrItemSource;
        public ICollection<ClientBRListModel> ClientsBRItemSource
        {
            get => _clientsBrItemSource;
            set
            {
                _clientsBrItemSource = value;
                OnPropertyChanged(() => ClientsBRItemSource);
            }
        }

        #endregion

        #region * * * METHODS  * * *

        private List<ClientBRListModel> ConvertToInternalModel(DataTable dataTable)
        {
            var itemSource = new List<ClientBRListModel>();

            var DTH = new DataTableHelper(dataTable.Columns);

            foreach (DataRow row in dataTable.Rows)
            {
                var obj = row.ItemArray;

                var item = new ClientBRListModel
                {
                    //RegId = DTC.CastInt(DTH.GetObject(obj, nameof(ClientSRListModel.RegId))),
                    //CustId = DTC.CastInt(DTH.GetObject(obj, nameof(ClientSRListModel.CustId))),
                    //CustName = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientSRListModel.CustName))),
                    //PeriodId = DTC.CastInt(DTH.GetObject(obj, nameof(ClientSRListModel.PeriodId))),
                    //PeriodName = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientSRListModel.PeriodName))),
                    //LicId = DTC.CastInt(DTH.GetObject(obj, nameof(ClientSRListModel.LicId))),
                    //FileName = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientSRListModel.FileName))),
                    //CreateDate = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(ClientSRListModel.CreateDate))),
                    //UserWho = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientSRListModel.UserWho))),
                    //RgStatus = DTC.CastInt(DTH.GetObject(obj, nameof(ClientSRListModel.RgStatus))),

                    //CountItem = DTC.CastInt(DTH.GetObject(obj, nameof(ClientSRListModel.CountItem))),
                    //CountNoFound = DTC.CastInt(DTH.GetObject(obj, nameof(ClientSRListModel.CountNoFound))),

                };

                itemSource.Add(item);
            }

            return itemSource;
        }

        private async Task LoadData(SearchModuleResource searchModuleResource = null)
        {
            var service = ConsumerBigRightService.GetInstance();

            IsBusy = true;
            var data = await service.GetClientsBRListAsync(searchModuleResource);

            if (data.IsSuccess)
            {
                if (TempDataTable == null || IsReloadData)
                    TempDataTable = data.Data;

                ClientsBRItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(data.Data));
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

        private void FilterList(string filterName)
        {
            if (ClientsBRItemSourceTemp == null)
                return;

            if (!string.IsNullOrEmpty(filterName))
            {
                IEnumerable<ClientBRListModel> list = null;
                filterName = filterName.ToUpper();

                //if (filterName == nameof(ClientSRListModel.StatusNoRelate).ToUpper())
                //    list = ClientsBRItemSourceTemp.Where(rec => rec.StatusNoRelate == 1);

                //if (filterName == nameof(ClientSRListModel.StatusNoActive).ToUpper())
                //    list = ClientsBRItemSourceTemp.Where(rec => rec.StatusNoActive == 1);

                //if (filterName == nameof(ClientSRListModel.StatusUnDistrib).ToUpper())
                //    list = ClientsBRItemSourceTemp.Where(rec => rec.StatusUnDistrib == 1);

                ClientsBRItemSource = list?.ToList();
            }
            else
            {
                ClientsBRItemSource = ClientsBRItemSourceTemp.ToList();
            }
        }

        private void GenerateTreeViewItems()
        {
            TreeViewItemSource = new ObservableCollection<RadTreeViewItem>
            {
                new RadTreeViewItem
                {
                    //Header = "Стан",
                    //Header = LOC.TV_CAT_STATE,
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
                            //Header = LOC.TV_ALL,
                            IsSelected = true,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },
                        new RadTreeViewItem
                        {
                            Name = "statusNoActive",
                            //Header = "Не підтверджені",
                            //Header = LOC.TV_NO_ACCEPT,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },
                        new RadTreeViewItem
                        {
                            Name = "statusNoRelate",
                            //Header = "Не прив'язані",
                            //Header = LOC.TV_NO_ATTACH,
                            FontWeight = FontWeights.Normal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        },
                        new RadTreeViewItem
                        {
                            Name = "statusUnDistrib",
                            //Header = "Не розподілені",
                            //Header = LOC.TV_NO_DISTRIB,
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
            ControlLoad(() =>
            {
                var searchControl = ((ClientSRListControl)o).searchControl;
                var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 3).FrameParam;
                ((SearchControlViewModel)searchControl.DataContext).Config = config;
                ((SearchControlViewModel)searchControl.DataContext).RunSearchQuery = async (search) => await LoadData(search);
                ((SearchControlViewModel)searchControl.DataContext).Clear = async () =>
                {
                    IsBusy = true;
                    ClientsBRItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(TempDataTable));
                    string name = SelectedTreeViewItem.Name;
                    await Task.Factory.StartNew(() => FilterList(name));
                    IsBusy = false;
                };
                ((SearchControlViewModel)searchControl.DataContext).UpdateData = async () =>
                {
                    IsReloadData = true;
                    await LoadData();
                };

                // todo implemented needed
                //AppLanguageLibrary.UpdateLanguageLocalization(LOC, nameof(AppLanguageLibrary.CurrentLanguage.ReportsSRListLD));

                GenerateTreeViewItems();

            });
        }

        public ICommand OpenClientCommand => new IPSDelegateCommand(OpenClientCommandExecute);
        private void OpenClientCommandExecute(object o)
        {

        }

        public ICommand Create_J_ClientCommand => new IPSDelegateCommand(Create_J_ClientCommandExecute);
        private void Create_J_ClientCommandExecute(object o)
        {

        }
        public ICommand Create_P_ClientCommand => new IPSDelegateCommand(Create_P_ClientCommandExecute);
        private void Create_P_ClientCommandExecute(object o)
        {

        }

        #endregion
    }
}
