using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IPSModulesLibrary.ClientSRList;
using IpsViewComponentLibrary.ConsumerControls;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using IPSViewComponentLibraryWPF.Controls.SearchControl;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.Windows.Controls;
using DTC = IPSViewComponentLibraryWPF.Extensions.DataTableConverter;

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

        private CabinetBigRightForm _cabinetBigRightForm;
        private CabinetBigRightForm CabinetBigRightForm
        {
            get
            {
                if (_cabinetBigRightForm == null)
                {
                    _cabinetBigRightForm = new CabinetBigRightForm();
                    _cabinetBigRightForm.cabinet.UpdateDataAction = async () =>
                    {
                        IsReloadData = true;
                        await LoadData();
                    };
                }

                return _cabinetBigRightForm;
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

        private async Task LoadData(SearchModuleResource searchModuleResource = null)
        {
            if (searchModuleResource == null)
                searchModuleResource = new SearchModuleResource();

            var service = ConsumerBigRightService.GetInstance();

            IsBusy = true;
            var data = await service.GetClientsBRListAsync(searchModuleResource);

            if (data.IsSuccess)
            {
                if (TempDataTable == null || IsReloadData)
                    TempDataTable = data.Data;

                ClientsBRItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(data.Data));
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

        private List<ClientBRListModel> ConvertToInternalModel(DataTable dataTable)
        {
            var itemSource = new List<ClientBRListModel>();

            var DTH = new DataTableHelper(dataTable.Columns);

            foreach (DataRow row in dataTable.Rows)
            {
                var obj = row.ItemArray;

                var item = new ClientBRListModel
                {
                    AgrDate = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(ClientBRListModel.AgrDate))),
                    DateBegin = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(ClientBRListModel.DateBegin))),
                    DateEnd = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(ClientBRListModel.DateEnd))),
                    DatePayLast = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(ClientBRListModel.DatePayLast))),
                    CustId = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CustId))),
                    AgrId = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.AgrId))),
                    AgrStatus = DTC.CastIntNull(DTH.GetObject(obj, nameof(ClientBRListModel.AgrStatus))),
                    AddStatus = DTC.CastIntNull(DTH.GetObject(obj, nameof(ClientBRListModel.AddStatus))),

                    CountLic1Active = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic1Active))),
                    CountLic1NoActive = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic1NoActive))),
                    CountLic1ToProlong = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic1ToProlong))),
                    CountLic1Close = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic1Close))),
                    CountLic2Active = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic2Active))),
                    CountLic2NoActive = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic2NoActive))),
                    CountLic2ForAccept = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic2ForAccept))),
                    CountLic2Rejected = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic2Rejected))),
                    CountLic3Active = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic3Active))),
                    CountLic3NoActive = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic3NoActive))),
                    CountLic3ForAccept = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic3ForAccept))),
                    CountLic3Rejected = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.CountLic3Rejected))),

                    ClcustId = DTC.CastIntNull(DTH.GetObject(obj, nameof(ClientBRListModel.ClcustId))),

                    StatusMasterActive = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.StatusMasterActive))),
                    StatusMasterNoactive = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.StatusMasterNoactive))),
                    StatusMasterProlong = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.StatusMasterProlong))),
                    StatusUndistribute = DTC.CastInt(DTH.GetObject(obj, nameof(ClientBRListModel.StatusUndistribute))),

                    UndistribAmount = DTC.CastFloat(DTH.GetObject(obj, nameof(ClientBRListModel.UndistribAmount))),
                    Borg = DTC.CastFloat(DTH.GetObject(obj, nameof(ClientBRListModel.Borg))),
                    UnattachAmount = DTC.CastAsFloat(DTH.GetObject(obj, nameof(ClientBRListModel.UnattachAmount))),
                    PrePayRest = DTC.CastAsFloat(DTH.GetObject(obj, nameof(ClientBRListModel.PrePayRest))),
                    Innokpo = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientBRListModel.Innokpo))),
                    Name = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientBRListModel.Name))),
                    AgrNumber = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientBRListModel.AgrNumber))),
                    JaCity = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientBRListModel.JaCity))),
                    PartnerName = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientBRListModel.PartnerName))),
                    JaAddress = DTC.Cast<string>(DTH.GetObject(obj, nameof(ClientBRListModel.JaAddress))),
                };

                itemSource.Add(item);
            }

            return itemSource;
        }

        private void FilterList(string filterName)
        {
            if (ClientsBRItemSourceTemp == null)
                return;

            if (!string.IsNullOrEmpty(filterName))
            {
                IEnumerable<ClientBRListModel> list = null;
                filterName = filterName.ToUpper();

                // Working
                if (filterName == nameof(ClientBRListModel.StatusMasterActive).ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.StatusMasterActive == 1);

                // NotAccepted
                if (filterName == "NotAccepted".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.AgrStatus == 1);

                // NotConfirmed
                if (filterName == "NotConfirmed".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.AgrStatus == 0);

                // ForProlongation
                if (filterName == "MasterProlong".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.StatusMasterProlong == 1);

                // Closed
                if (filterName == "Closed".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.AgrStatus == 4);

                // ліцензії
                // All
                if (filterName == "licenseAll".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic1Active + rec.CountLic1NoActive + rec.CountLic1ToProlong + rec.CountLic1Close > 0);
                // Working
                if (filterName == "Lic1Active".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic1Active > 0);
                // ForProlongation
                if (filterName == "Lic1ToProlong".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic1ToProlong > 0);
                // closed
                if (filterName == "Lic1Close".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic1Close > 0);

                // заявки
                // All
                if (filterName == "requestAll".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic2Active + rec.CountLic2NoActive + rec.CountLic2ForAccept + rec.CountLic2Rejected> 0);
                // Working
                if (filterName == "Lic2Active".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic2Active > 0);
                // NotActive
                if (filterName == "Lic2NoActive".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic2NoActive > 0);
                // onaccept
                if (filterName == "Lic2ForAccept".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic2ForAccept > 0);
                // rejected
                if (filterName == "Lic2Rejected".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic2Rejected > 0);

                // довідки
                // All
                if (filterName == "referenceALl".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic3Active + rec.CountLic3NoActive + rec.CountLic3ForAccept + rec.CountLic3Rejected > 0);
                // Working
                if (filterName == "Lic3Active".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic3Active > 0);
                // NotActive      
                if (filterName == "Lic3NoActive".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic3NoActive > 0);
                // onaccept       
                if (filterName == "Lic3ForAccept".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic3ForAccept > 0);
                // rejected       
                if (filterName == "Lic3Rejected".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.CountLic3Rejected > 0);

                // Debt
                if (filterName == "Debt".ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.Borg > 0);

                // UnattachAmount
                if (filterName == nameof(ClientBRListModel.UnattachAmount).ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.UnattachAmount > 0);

                // ForDistribution
                if (filterName == nameof(ClientBRListModel.StatusUndistribute).ToUpper())
                    list = ClientsBRItemSourceTemp.Where(rec => rec.StatusUndistribute == 1);

                ClientsBRItemSource = list?.ToList();
            }
            else
            {
                ClientsBRItemSource = ClientsBRItemSourceTemp.ToList();
            }
        }
        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            ControlLoad(() =>
            {
                var searchControl = ((ClientBRListControl)o).searchControl;
                var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 4).FrameParam;
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
            });
        }

        public ICommand OpenClientCommand => new IPSDelegateCommand(OpenClientCommandExecute);
        private void OpenClientCommandExecute(object o)
        {
            var client = (ClientBRListModel)o;
            ViewsSingleton.SetConsumerBigRightView(client);
            
            //// завантаження даних
            CabinetBigRightForm.cabinet.LoadData(client.CustId);
            CabinetBigRightForm.Title = client.Name;

            WindowsFormsVisible.ShowHiddenWindow(CabinetBigRightForm);
        }

        private const string AddNewConsumerSuccess = "Нового користувача додано!";
        private const string AddNewConsumerError = "Не вдалося додати нового користувача!";
        public ICommand CreateClientCommand => new IPSDelegateCommand(CreateClientCommandExecute);
        private async void CreateClientCommandExecute(object o)
        {
            var service = ClientSmallRightService.GetInstance();

            int custType = 3; // Юридична особа
            var customer = service.NewCustomer(custType);
            using (var form = new AnketaConsumerJurForm(customer, service.GetAutoCompleteList, service.GetData, TypeRights.BigRights))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var relust = service.Save(customer);
                    MessageShow.ShowInfoByResult(AddNewConsumerSuccess, AddNewConsumerError, relust);
                    
                    IsReloadData = true;
                    await LoadData();
                }
            }
        }

        #endregion
    }
}
