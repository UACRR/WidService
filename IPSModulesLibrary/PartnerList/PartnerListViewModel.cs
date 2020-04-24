using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsFormsDesign.Data;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.RegisterControls;
using IPSViewComponentLibraryWPF.Controls.SearchControl;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using LanguageLibrary;
using Telerik.Windows.Controls;
using DTC = IPSViewComponentLibraryWPF.Extensions.DataTableConverter;

namespace IPSModulesLibrary.PartnerList
{
    public class PartnerListViewModel : IPSViewModel<LM_PartnerList>
    {
        public PartnerListViewModel()
        {
            LazyLoadDataAction = async () => await LoadData();
        }

        #region * * * PROPERTIES * * *

        private bool IsReloadData { get; set; }

        private ICollection<PartnerListModel> PartnersItemSourceTemp;
        private ICollection<PartnerListModel> _partnersItemSource;
        public ICollection<PartnerListModel> PartnersItemSource
        {
            get => _partnersItemSource;
            set
            {
                _partnersItemSource = value;
                OnPropertyChanged(() => PartnersItemSource);
            }
        }


        private RadTreeViewItem _selectedTreeViewItem;
        public RadTreeViewItem SelectedTreeViewItem
        {
            get => _selectedTreeViewItem;
            set
            {
                _selectedTreeViewItem = value;

                string name = _selectedTreeViewItem?.Name;
                FilterItemsList(name);
                OnPropertyChanged(() => SelectedTreeViewItem);
            }
        }

        #endregion

        #region * * * METHODS  * * *

        private async Task LoadData(SearchModuleResource searchModuleResource = null)
        {
            if (searchModuleResource == null)
                searchModuleResource = new SearchModuleResource();

            var service = PartnerService.GetInstance();

            IsBusy = true;
            var data = await service.GetPartnersList(searchModuleResource);

            if (data.IsSuccess)
            {
                if (TempDataTable == null || IsReloadData)
                    TempDataTable = data.Data;

                PartnersItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(data.Data));
                string name = SelectedTreeViewItem?.Name;
                await Task.Factory.StartNew(() => FilterItemsList(name));
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

        private List<PartnerListModel> ConvertToInternalModel(DataTable dataTable)
        {
            var itemSource = new List<PartnerListModel>();

            var DTH = new DataTableHelper(dataTable.Columns);

            foreach (DataRow row in dataTable.Rows)
            {
                var obj = row.ItemArray;

                var item = new PartnerListModel
                {
                    //RegId = DTC.CastInt(DTH.GetObject(obj, nameof(PartnerListModel.RegId))),
                    //CustId = DTC.CastInt(DTH.GetObject(obj, nameof(PartnerListModel.CustId))),
                    //CustName = DTC.Cast<string>(DTH.GetObject(obj, nameof(PartnerListModel.CustName))),
                    //PeriodId = DTC.CastInt(DTH.GetObject(obj, nameof(PartnerListModel.PeriodId))),
                    //PeriodName = DTC.Cast<string>(DTH.GetObject(obj, nameof(PartnerListModel.PeriodName))),
                    //LicId = DTC.CastInt(DTH.GetObject(obj, nameof(PartnerListModel.LicId))),
                    //FileName = DTC.Cast<string>(DTH.GetObject(obj, nameof(PartnerListModel.FileName))),
                    //CreateDate = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(PartnerListModel.CreateDate))),
                    //UserWho = DTC.Cast<string>(DTH.GetObject(obj, nameof(PartnerListModel.UserWho))),
                    //RgStatus = DTC.CastInt(DTH.GetObject(obj, nameof(PartnerListModel.RgStatus))),

                    //CountItem = DTC.CastInt(DTH.GetObject(obj, nameof(PartnerListModel.CountItem))),
                    //CountNoFound = DTC.CastInt(DTH.GetObject(obj, nameof(PartnerListModel.CountNoFound))),

                };

                itemSource.Add(item);
            }

            return itemSource;
        }

        private void FilterItemsList(string filterName)
        {
            if (PartnersItemSourceTemp == null)
                return;

            if (!string.IsNullOrEmpty(filterName))
            {
                IEnumerable<PartnerListModel> list = null;
                filterName = filterName.ToUpper();

                if (filterName == "Active".ToUpper())
                    list = PartnersItemSourceTemp.Where(rec => rec.AgrStatus == 2);

                if (filterName == "OnAccept".ToUpper())
                    list = PartnersItemSourceTemp.Where(rec => rec.AgrStatus == 1);

                if (filterName == "NotAccept".ToUpper())
                    list = PartnersItemSourceTemp.Where(rec => rec.AgrStatus == 0);

                PartnersItemSource = list?.ToList();
            }
            else
            {
                PartnersItemSource = PartnersItemSourceTemp.ToList();
            }
        }

        private void CreatePartner(int type)
        {

        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            ControlLoad(() =>
            {
                var searchControl = ((PartnerListControl) o).searchControl;
                var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 9).FrameParam;
                ((SearchControlViewModel)searchControl.DataContext).Config = config;
                ((SearchControlViewModel)searchControl.DataContext).RunSearchQuery = async (search) => await LoadData(search);
                ((SearchControlViewModel)searchControl.DataContext).Clear = async () =>
                {
                    IsBusy = true;
                    PartnersItemSourceTemp = await Task.Factory.StartNew(() => ConvertToInternalModel(TempDataTable));
                    string name = SelectedTreeViewItem.Name;
                    await Task.Factory.StartNew(() => FilterItemsList(name));
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

        public ICommand OpenPartnerCommand => new IPSDelegateCommand(OpenPartnerCommandExecute);
        private void OpenPartnerCommandExecute(object o)
        {
            if (o == null)
                return;


        }

        public ICommand Create_J_PartnerCommand => new IPSDelegateCommand(Create_J_PartnerCommandExecute);
        private void Create_J_PartnerCommandExecute(object o)
        {
            CreatePartner(3);
        }

        public ICommand Create_P_PartnerCommand => new IPSDelegateCommand(Create_P_PartnerCommandExecute);
        private void Create_P_PartnerCommandExecute(object o)
        {
            CreatePartner(1);
        }

        #endregion
    }
}
