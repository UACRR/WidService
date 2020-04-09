using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.Controls.SearchControl;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using DTC = IPSViewComponentLibraryWPF.Extensions.DataTableConverter;

namespace IPSModulesLibrary.ReportsBRList
{
    public class ReportsBRListViewModel : IPSViewModel<LM_ReportsBRList>
    {
        public ReportsBRListViewModel()
        {
            LazyLoadDataAction = async () => await LoadData();
        }

        #region * * * PROPERTIES * * *

        private bool IsReloadData { get; set; }
        private bool IsFiltersClearing { get; set; }

        private ICollection<ReportsBRListModel> ReportsItemSourceTemp;
        private ICollection<ReportsBRListModel> _reportsItemSource;
        public ICollection<ReportsBRListModel> ReportsItemSource
        {
            get => _reportsItemSource;
            set
            {
                _reportsItemSource = value;
                OnPropertyChanged(() => ReportsItemSource);
            }
        }

        private ICollection<AgreementStatus> _statusItemSource;
        public ICollection<AgreementStatus> StatusItemSource
        {
            get => _statusItemSource;
            set
            {
                _statusItemSource = value;
                OnPropertyChanged(() => StatusItemSource);
            }
        }

        private AgreementStatus _selectedStatus;
        public AgreementStatus SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                FilterItemsList();
                OnPropertyChanged(() => SelectedStatus);
            }
        }

        private ICollection<LicenseType> _licenseType;
        public ICollection<LicenseType> LicenseType
        {
            get => _licenseType;
            set
            {
                _licenseType = value;
                OnPropertyChanged(() => LicenseType);
            }
        }

        private LicenseType _selectedLicenseType;
        public LicenseType SelectedLicenseType
        {
            get => _selectedLicenseType;
            set
            {
                _selectedLicenseType = value;
                OnPropertyChanged(() => SelectedLicenseType);
            }
        }

        #endregion

        #region * * * METHODS  * * *

        private async Task LoadData(SearchModuleResource searchModuleResource = null)
        {
            if (searchModuleResource == null)
                searchModuleResource = new SearchModuleResource();

            var service = new RegisterService();

            IsBusy = true;
            var data = await service.GetSRReportsList(searchModuleResource);

            if (data.IsSuccess)
            {
                if (TempDataTable == null || IsReloadData)
                    TempDataTable = data.Data;

                ReportsItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(data.Data));
                FilterItemsList();
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

        private List<ReportsBRListModel> ConvertToInternalModel(DataTable dataTable)
        {
            var itemSource = new List<ReportsBRListModel>();

            var DTH = new DataTableHelper(dataTable.Columns);

            foreach (DataRow row in dataTable.Rows)
            {
                var obj = row.ItemArray;

                var item = new ReportsBRListModel
                {
                    //RegId = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsBRListModel.RegId))),
                    //CustId = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsBRListModel.CustId))),
                    //CustName = DTC.Cast<string>(DTH.GetObject(obj, nameof(ReportsBRListModel.CustName))),
                    //PeriodId = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsBRListModel.PeriodId))),
                    //PeriodName = DTC.Cast<string>(DTH.GetObject(obj, nameof(ReportsBRListModel.PeriodName))),
                    //LicId = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsBRListModel.LicId))),
                    //FileName = DTC.Cast<string>(DTH.GetObject(obj, nameof(ReportsBRListModel.FileName))),
                    //CreateDate = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(ReportsBRListModel.CreateDate))),
                    //UserWho = DTC.Cast<string>(DTH.GetObject(obj, nameof(ReportsBRListModel.UserWho))),
                    //RgStatus = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsBRListModel.RgStatus))),

                    //CountItem = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsBRListModel.CountItem))),
                    //CountNoFound = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsBRListModel.CountNoFound))),

                };

                itemSource.Add(item);
            }

            return itemSource;
        }

        private void FilterItemsList()
        {
            if (IsFiltersClearing)
                return;

            Task.Factory.StartNew(() =>
            {
                Func<ReportsBRListModel, bool> predicate = item =>
                {
                    bool e = true;



                    return e;
                };

                ReportsItemSource = ReportsItemSourceTemp?.Where(predicate).ToList();
            });
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            ControlLoad(() =>
            {

                StatusItemSource = new List<AgreementStatus>
                {
                    new AgreementStatus
                    {
                        CodeI = -1, Name = "Всі"
                    }
                };
                
                int[] status = new[] { 2, 3, 4, 5 };
                var statuses = IpsGlobal.AnketaDictionaties.agreementStatus.Where(rec => status.Contains(rec.CodeI)).ToList();

                foreach (var agreementStatuse in statuses)
                {
                    StatusItemSource.Add(agreementStatuse);
                }


                int[] types = { 1, 2, 3 };
                var lictypes = IpsGlobal.AnketaDictionaties.licenseType.Where(rec => types.Contains(rec.CodeI));

                
                
                var searchControl = ((ReportsBRListControl)o).searchControl;
                var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 6).FrameParam;
                ((SearchControlViewModel)searchControl.DataContext).Config = config;
                ((SearchControlViewModel)searchControl.DataContext).RunSearchQuery = async (search) => await LoadData(search);
                ((SearchControlViewModel)searchControl.DataContext).Clear = async () =>
                {
                    IsBusy = true;
                    ReportsItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(TempDataTable));
                    IsBusy = false;
                    FilterItemsList();
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

        public ICommand OpenReportCommand => new IPSDelegateCommand(OpenReportCommandExecute);
        private void OpenReportCommandExecute(object o)
        {
            if (o == null)
                return;

            var service = new RegisterService();
            //var id = ((ReportsBRListModel)o).RegId;

        }

        public ICommand ClearFiltersCommand => new IPSDelegateCommand(ClearFiltersCommandExecute);
        private void ClearFiltersCommandExecute(object o)
        {
            IsFiltersClearing = true;

            SelectedStatus = null;
            SelectedLicenseType = null;

            IsFiltersClearing = false;

            FilterItemsList();
        }

        #endregion
    }
}