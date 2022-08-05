using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.RegisterControls;
using IPSViewComponentLibraryWPF.Controls.SearchControl;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using DTC = IPSViewComponentLibraryWPF.Extensions.DataTableConverter;

namespace IPSModulesLibrary.ReportsOnlineList
{
    public class ReportsOnlineListViewModel : IPSViewModel<LM_ReportsOnlineList>
    {
        public ReportsOnlineListViewModel()
        {
            LazyLoadDataAction = async () => await LoadData();
        }

        #region * * * PROPERTIES * * *

        private bool IsReloadData { get; set; }
        private bool IsFiltersClearing { get; set; }

        private ICollection<ReportsOnlineListModel> ReportsItemSourceTemp;
        private ICollection<ReportsOnlineListModel> _reportsItemSource;
        public ICollection<ReportsOnlineListModel> ReportsItemSource
        {
            get => _reportsItemSource;
            set
            {
                _reportsItemSource = value;
                OnPropertyChanged(() => ReportsItemSource);
            }
        }

        private DateTime? _dateBegin;
        public DateTime? DateBegin
        {
            get => _dateBegin;
            set
            {
                _dateBegin = value;
                FilterItemsList();
                OnPropertyChanged(() => DateBegin);
            }
        }

        private DateTime? _dateEnd;
        public DateTime? DateEnd
        {
            get => _dateEnd;
            set
            {
                _dateEnd = value;
                FilterItemsList();
                OnPropertyChanged(() => DateEnd);
            }
        }

        private ICollection<RegisterStatus> _statusItemSource;
        public ICollection<RegisterStatus> StatusItemSource
        {
            get => _statusItemSource;
            set
            {
                _statusItemSource = value;
                OnPropertyChanged(() => StatusItemSource);
            }
        }

        private RegisterStatus _selectedStatus;
        public RegisterStatus SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                FilterItemsList();
                OnPropertyChanged(() => SelectedStatus);
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
            var data = await service.GetOnlineReportsList(searchModuleResource);

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

        private List<ReportsOnlineListModel> ConvertToInternalModel(DataTable dataTable)
        {
            var itemSource = new List<ReportsOnlineListModel>();

            var DTH = new DataTableHelper(dataTable.Columns);

            foreach (DataRow row in dataTable.Rows)
            {
                var obj = row.ItemArray;

                var item = new ReportsOnlineListModel
                {
                    RegId = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsOnlineListModel.RegId))),
                    CustId = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsOnlineListModel.CustId))),
                    CustName = DTC.Cast<string>(DTH.GetObject(obj, nameof(ReportsOnlineListModel.CustName))),
                    PeriodId = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsOnlineListModel.PeriodId))),
                    PeriodName = DTC.Cast<string>(DTH.GetObject(obj, nameof(ReportsOnlineListModel.PeriodName))),
                    LicId = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsOnlineListModel.LicId))),
                    FileName = DTC.Cast<string>(DTH.GetObject(obj, nameof(ReportsOnlineListModel.FileName))),
                    CreateDate = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(ReportsOnlineListModel.CreateDate))),
                    UserWho = DTC.Cast<string>(DTH.GetObject(obj, nameof(ReportsOnlineListModel.UserWho))),
                    RgStatus = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsOnlineListModel.RgStatus))),

                    CountItem = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsOnlineListModel.CountItem))),
                    CountNoFound = DTC.CastInt(DTH.GetObject(obj, nameof(ReportsOnlineListModel.CountNoFound))),

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
                Func<ReportsOnlineListModel, bool> predicate = item =>
                {
                    bool e = true;

                    if (DateBegin.HasValue)
                        e = item.CreateDate >= DateBegin;
                    if (DateEnd.HasValue)
                        e = e && item.CreateDate <= DateEnd;
                    if (SelectedStatus != null)
                        e = e && item.RgStatus == SelectedStatus.CodeI;

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
                StatusItemSource = IpsGlobal.AnketaDictionaties.registerStatus.ToList();

                var searchControl = ((ReportsOnlineListControl)o).searchControl;
                var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 8).FrameParam;
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
            var id = ((ReportsOnlineListModel)o).RegId;


            using (var view = new RegisterCCIDView())
            {
                var presenter = new RegisterCCIDPresenter(view, service);
                presenter.Show(id);
            }
        }

        public ICommand ClearFiltersCommand => new IPSDelegateCommand(ClearFiltersCommandExecute);
        private void ClearFiltersCommandExecute(object o)
        {
            IsFiltersClearing = true;

            DateBegin = null;
            DateEnd = null;
            SelectedStatus = null;

            IsFiltersClearing = false;

            FilterItemsList();
        }

        #endregion
    }
}
