using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ConsumerForms;
using IPSViewComponentLibraryWPF.Controls.SearchControl;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using LanguageLibrary;
using Telerik.Windows.Controls;
using DTC = IPSViewComponentLibraryWPF.Extensions.DataTableConverter;

namespace IPSModulesLibrary.ClientSRList
{
    public class ClientSRListViewModel : IPSViewModel<LM_ClientSRList>
    {
        public ClientSRListViewModel()
        {
            LazyLoadDataAction = async () => await LoadData();
        }

        #region * * * PROPERTIES * * *


        private CabinetSmallRightForm _cabinetSmallRightForm;
        private CabinetSmallRightForm CabinetSmallRightForm
        {
            get
            {
                if (_cabinetSmallRightForm == null)
                    _cabinetSmallRightForm = new CabinetSmallRightForm();
                
                return _cabinetSmallRightForm;
            }
        }

        private bool IsReloadData { get; set; }

        private RadTreeViewItem _selectedTreeViewItem;
        public RadTreeViewItem SelectedTreeViewItem
        {
            get => _selectedTreeViewItem;
            set
            {
                _selectedTreeViewItem = value;

                string name = _selectedTreeViewItem?.Name;
                FilterList(name);
                OnPropertyChanged(() => SelectedTreeViewItem);
            }
        }

        private ICollection<ClientSRListModel> ClientsSRItemSourceTemp { get; set; }
        private ICollection<ClientSRListModel> _clientsSrItemSource;
        public ICollection<ClientSRListModel> ClientsSRItemSource
        {
            get => _clientsSrItemSource;
            set
            {
                _clientsSrItemSource = value;
                OnPropertyChanged(() => ClientsSRItemSource);
            }
        }

        #endregion

        #region * * * METHODS  * * *

        private async Task LoadData(SearchModuleResource searchModuleResource = null)
        {

            if (searchModuleResource == null)
                searchModuleResource = new SearchModuleResource();

            var service = ClientSmallRightService.GetInstance();

            IsBusy = true;
            var data = await service.GetClientsSRListAsync(searchModuleResource);

            if (data.IsSuccess)
            {
                if (TempDataTable == null || IsReloadData)
                    TempDataTable = data.Data;

                ClientsSRItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(data.Data));
                string name = SelectedTreeViewItem?.Name;
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

        private List<ClientSRListModel> ConvertToInternalModel(DataTable dataTable)
        {
            var itemSource = new List<ClientSRListModel>();

            var DTH = new DataTableHelper(dataTable.Columns);

            foreach (DataRow row in dataTable.Rows)
            {
                var obj = row.ItemArray;

                var item = new ClientSRListModel
                {
                    CustId = DTC.CastIntNull(DTH.GetObject(obj, nameof(ClientSRListModel.CustId))),
                    Name = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientSRListModel.Name))),
                    INNOKPO = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientSRListModel.INNOKPO))),
                    CountActive = DTC.CastIntNull(DTH.GetObject(obj, nameof(ClientSRListModel.CountActive))),
                    CountNoAccept = DTC.CastIntNull(DTH.GetObject(obj, nameof(ClientSRListModel.CountNoAccept))),
                    
                    AmountBorg = DTC.CastAsFloat(DTH.GetObject(obj, nameof(ClientSRListModel.AmountBorg))),
                    UnattachAmount = DTC.CastAsFloat(DTH.GetObject(obj, nameof(ClientSRListModel.UnattachAmount))),
                    UndistribAmount = DTC.CastAsFloat(DTH.GetObject(obj, nameof(ClientSRListModel.UndistribAmount))),
                    
                    StatusActive = DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.StatusActive))),
                    StatusNoAccept= DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.StatusNoAccept))),
                    StatusForAccept= DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.StatusForAccept))),
                    StatusProlong = DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.StatusProlong))),
                    StatusClose = DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.StatusClose))),
                    
                    StatusUnattach = DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.StatusUnattach))),
                    StatusUndistribute = DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.StatusUndistribute))),
                    StatusBorg = DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.StatusBorg))),

                    StatusNoMoney = DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.StatusNoMoney))),
                    StatusNoReport = DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.StatusNoReport))),
                    
                    RgStatusOk = DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.RgStatusOk))),
                    RgStatusRefuse = DTC.CastAsByte(DTH.GetObject(obj, nameof(ClientSRListModel.RgStatusRefuse))),
                };

                itemSource.Add(item);
            }

            return itemSource;
        }

        private void FilterList(string filterName)
        {
            if (ClientsSRItemSourceTemp == null)
                return;

            if (!string.IsNullOrEmpty(filterName))
            {
                IEnumerable<ClientSRListModel> list = null;
                filterName = filterName.ToUpper();

                if (filterName == nameof(ClientSRListModel.StatusActive).ToUpper())
                    list = ClientsSRItemSourceTemp.Where(rec => rec.StatusActive == 1);

                if (filterName == nameof(ClientSRListModel.StatusNoAccept).ToUpper()) 
                    list = ClientsSRItemSourceTemp.Where(rec => rec.StatusNoAccept == 1);

                if (filterName == nameof(ClientSRListModel.StatusForAccept).ToUpper()) 
                    list = ClientsSRItemSourceTemp.Where(rec => rec.StatusForAccept == 1);

                if (filterName == nameof(ClientSRListModel.StatusProlong).ToUpper()) 
                    list = ClientsSRItemSourceTemp.Where(rec => rec.StatusProlong == 1);

                if (filterName == nameof(ClientSRListModel.StatusClose).ToUpper())
                    list = ClientsSRItemSourceTemp.Where(rec => rec.StatusClose == 1);

                if (filterName == nameof(ClientSRListModel.StatusUnattach).ToUpper())
                    list = ClientsSRItemSourceTemp.Where(rec => rec.StatusUnattach == 1);

                if (filterName == nameof(ClientSRListModel.StatusUndistribute).ToUpper())
                    list = ClientsSRItemSourceTemp.Where(rec => rec.StatusUndistribute == 1);

                if (filterName == nameof(ClientSRListModel.StatusBorg).ToUpper())
                    list = ClientsSRItemSourceTemp.Where(rec => rec.StatusBorg == 1);

                if (filterName == nameof(ClientSRListModel.StatusNoMoney).ToUpper())
                    list = ClientsSRItemSourceTemp.Where(rec => rec.StatusNoMoney == 1);

                if (filterName == nameof(ClientSRListModel.StatusNoReport).ToUpper())
                    list = ClientsSRItemSourceTemp.Where(rec => rec.StatusNoReport == 1);

                if (filterName == nameof(ClientSRListModel.RgStatusOk).ToUpper())
                    list = ClientsSRItemSourceTemp.Where(rec => rec.RgStatusOk == 1);

                if (filterName == nameof(ClientSRListModel.RgStatusRefuse).ToUpper())
                    list = ClientsSRItemSourceTemp.Where(rec => rec.RgStatusRefuse == 1);

                ClientsSRItemSource = list?.ToList();
            }
            else
            {
                ClientsSRItemSource = ClientsSRItemSourceTemp.ToList();
            }
        }

        private const string ConsumerAdded = "Нового користувача додано!";
        private const string ConsumerNotAdded = "Не вдалося додати нового користувача!";
        private async void CreateClient(int custType)
        {
            var service = ClientSmallRightService.GetInstance();

            var customer = service.NewCustomer(custType);
            var saveDialogResult = false;

            switch (custType)
            {
                // фізична особа
                case 1:
                {
                    using (var formPhis = new AnketaConsumerPhisForm(customer))
                    {
                        saveDialogResult = formPhis.ShowDialog() == System.Windows.Forms.DialogResult.OK;
                    }

                    break;
                }
                // юридична особа
                case 3:
                {
                    using (var form = new AnketaConsumerJurForm(customer, service.GetAutoCompleteList, service.GetData))
                    {
                        saveDialogResult = form.ShowDialog() == System.Windows.Forms.DialogResult.OK;
                    }

                    break;
                }
            }

            if (saveDialogResult)
            {
                var relust = service.Save(customer);
                ShowMessage.ShowInfoByResult(ConsumerAdded, ConsumerNotAdded, relust);

                IsReloadData = true;
                await LoadData();
            }

            GC.Collect();
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            ControlLoad(() =>
            {
                var searchControl = ((ClientSRListControl) o).searchControl;
                var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 3).FrameParam;
                ((SearchControlViewModel)searchControl.DataContext).Config = config;
                ((SearchControlViewModel)searchControl.DataContext).RunSearchQuery = async (search) => await LoadData(search);
                ((SearchControlViewModel)searchControl.DataContext).Clear = async () =>
                {
                    IsBusy = true;
                    ClientsSRItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(TempDataTable));
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
            });
        }

        public ICommand OpenClientCommand => new IPSDelegateCommand(OpenClientCommandExecute);
        private void OpenClientCommandExecute(object o)
        {
            var customer = (ClientSRListModel) o;
            var service = ClientSmallRightService.GetInstance();

            Customer mainCust = null, regCust = null;
            Task[] getCustData = new Task[2];

            getCustData[0] = Task.Run(() => { mainCust = service.GetData(customer.CustId.Value); });
            getCustData[1] = Task.Run(() => { regCust = service.GetRatedListForCust(customer.CustId.Value); });
            Task.WaitAll(getCustData);

            CabinetSmallRightForm.CloneRegisterRL(mainCust, regCust);

            ApplicationCustomerData.GetInstance().CurrentCustomer = mainCust;
            ApplicationCustomerData.GetInstance().CustomerName = customer.Name;

            CabinetSmallRightForm.SetCustomer(mainCust);
            CabinetSmallRightForm.Title = customer?.Name;

            IpsViewComponentLibrary.Extensions.WindowsFormsVisible.ShowHiddenWindow(CabinetSmallRightForm);
        }

        public ICommand Create_J_ClientCommand => new IPSDelegateCommand(Create_J_ClientCommandExecute);
        private void Create_J_ClientCommandExecute(object o)
        {
            CreateClient(3);
        }

        public ICommand Create_P_ClientCommand => new IPSDelegateCommand(Create_P_ClientCommandExecute);
        private void Create_P_ClientCommandExecute(object o)
        {
            CreateClient(1);
        }

        #endregion
    }
}
