using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.ObjectRightControls;
using IpsViewComponentLibrary.Shared.Forms;
using IPSViewComponentLibraryWPF.Controls.SearchControl;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using LanguageLibrary;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using DTC = IPSViewComponentLibraryWPF.Extensions.DataTableConverter;

namespace IPSModulesLibrary.ReportsBRList
{
    public class LicenseBRListViewModel : IPSViewModel<LM_LicenseBRList>
    {
        public LicenseBRListViewModel()
        {
            LazyLoadDataAction = async () => await LoadData();
        }

        #region * * * PROPERTIES * * *

        private bool IsReloadData { get; set; }

        private bool _isShowRowDetails;
        public bool IsShowRowDetails
        {
            get => _isShowRowDetails;
            set
            {
                _isShowRowDetails = value;
                RowDetailsVisibilityMode = value ? GridViewRowDetailsVisibilityMode.VisibleWhenSelected : GridViewRowDetailsVisibilityMode.Collapsed;
                OnPropertyChanged(() => IsShowRowDetails);
            }
        }

        private GridViewRowDetailsVisibilityMode _rowDetailsVisibilityMode = GridViewRowDetailsVisibilityMode.Collapsed;
        public GridViewRowDetailsVisibilityMode RowDetailsVisibilityMode
        {
            get => _rowDetailsVisibilityMode;
            set
            {
                _rowDetailsVisibilityMode = value;
                OnPropertyChanged(() => RowDetailsVisibilityMode);
            }
        }

        private ICollection<LicenseBRListModel> ReportsItemSourceTemp;
        private ICollection<LicenseBRListModel> _reportsItemSource;
        public ICollection<LicenseBRListModel> ReportsItemSource
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

        private List<int?> LicenseTypeCodes { get; } = new List<int?>();

        #endregion

        #region * * * METHODS  * * *

        private async Task LoadData(SearchModuleResource searchModuleResource = null)
        {
            if (searchModuleResource == null)
                searchModuleResource = new SearchModuleResource();

            var service = LicenseBRService.GetInstance();

            IsBusy = true;
            var data = await service.GetLicenseBRList(searchModuleResource);

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

        private List<LicenseBRListModel> ConvertToInternalModel(DataTable dataTable)
        {
            var itemSource = new List<LicenseBRListModel>();

            var DTH = new DataTableHelper(dataTable.Columns);

            foreach (DataRow row in dataTable.Rows)
            {
                var obj = row.ItemArray;

                var item = new LicenseBRListModel
                {
                    CustId = DTC.CastIntNull(DTH.GetObject(obj, nameof(LicenseBRListModel.CustId))),
                    Name = DTC.Cast<string>(DTH.GetObject(obj, nameof(LicenseBRListModel.Name))),
                    
                    Objid = DTC.CastIntNull(DTH.GetObject(obj, nameof(LicenseBRListModel.Objid))),
                    ObjName = DTC.Cast<string>(DTH.GetObject(obj, nameof(LicenseBRListModel.ObjName))),

                    LicId = DTC.CastInt(DTH.GetObject(obj, nameof(LicenseBRListModel.LicId))),
                    LicType = DTC.CastIntNull(DTH.GetObject(obj, nameof(LicenseBRListModel.LicType))),
                    LicStatus = DTC.CastIntNull(DTH.GetObject(obj, nameof(LicenseBRListModel.LicStatus))),

                    LicNum = DTC.Cast<string>(DTH.GetObject(obj, nameof(LicenseBRListModel.LicNum))),
                    LicDate = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(LicenseBRListModel.LicDate))),
                    DatePremiere = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(LicenseBRListModel.DatePremiere))),
                    LicDateBegin = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(LicenseBRListModel.LicDateBegin))),
                    LicDateEnd = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(LicenseBRListModel.LicDateEnd))),

                    GenreType = DTC.CastIntNull(DTH.GetObject(obj, nameof(LicenseBRListModel.GenreType))),

                    Comment = DTC.Cast<string>(DTH.GetObject(obj, nameof(LicenseBRListModel.Comment))),
                };

                itemSource.Add(item);
            }

            return itemSource;
        }

        private void FilterItemsList()
        {
            Task.Factory.StartNew(() =>
            {
                Func<LicenseBRListModel, bool> predicate = item =>
                {
                    bool e = true;

                    if (LicenseTypeCodes.Any())
                        e = LicenseTypeCodes.Contains(item.LicType);

                    if (SelectedStatus != null)
                        e = e && item.LicStatus == SelectedStatus.CodeI;

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
                LicenseType = IpsGlobal.AnketaDictionaties.licenseType.Where(rec => types.Contains(rec.CodeI)).ToList();

                var searchControl = ((LicenseBRListControl)o).searchControl;
                var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 7).FrameParam;
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
                //AppLanguageLibrary.UpdateLanguageLocalization(LOC, nameof(AppLanguageLibrary.CurrentLanguage.LicenseBRListLD));
            });
        }

        public ICommand OpenLicenseCommand => new IPSDelegateCommand(OpenLicenseCommandExecute);
        private void OpenLicenseCommandExecute(object o)
        {
            var id = ((LicenseBRListModel) o)?.Objid;

            if (!id.HasValue) 
                return;
            
            using (var view = new ObjectRightBrView())
            {
                var presenter = new ObjectRightBrPresenter(view);
                presenter.Show(id.Value);
            }
        }

        public ICommand EditLicenseCommand => new IPSDelegateCommand(EditLicenseCommandExecute);
        private async void EditLicenseCommandExecute(object o)
        {
            var item = (LicenseBRListModel) o;

            if (!item.CustId.HasValue)
                return;

            int custId = item.CustId.Value;

            var consumerService = ConsumerBigRightService.GetInstance();
            var consumer = consumerService.GetData(custId);
            var bigRightView = consumerService.GetMainBigRightView().FirstOrDefault(rec => rec.CustId == custId);

            if (bigRightView == null)
                return;

            var view = new RequestForm(consumer, bigRightView, ScopeOfUseForm.Edit, item.LicId, RequestForm.FormMode.ForSmallRightAdmin);

            if (view.ShowDialog() == DialogResult.OK)
            {
                var result = consumerService.Save(consumer);

                if (result)
                {
                    IsReloadData = true;
                    await LoadData();
                }
                else
                {
                    ShowMessage.ShowError("Не вдалося зберегти зміни!");
                }
            }
        }

        //public ICommand LicenseTypeChangedCommand => new IPSDelegateCommand(LicenseTypeChangedCommandExecute);
        //private void LicenseTypeChangedCommandExecute(object o)
        //{
        //    LicenseTypeCodes.Clear();

        //    var list = (System.Collections.ICollection) o;
        //    foreach (var item in list)
        //    {
        //        var code = ((LicenseType) item).CodeI;
        //        LicenseTypeCodes.Add(code);
        //    }

        //    FilterItemsList();
        //}

        #endregion
    }
}