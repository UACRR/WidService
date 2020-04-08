using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.CommunityControls;
using IpsViewComponentLibrary.CommunityControls.InternalModel;
using IPSViewComponentLibraryWPF.Controls.SearchControl;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;
using LanguageLibrary;
using Telerik.Windows.Controls;
using DTC = IPSViewComponentLibraryWPF.Extensions.DataTableConverter;

namespace IPSModulesLibrary.CommunitiesList
{
    public class CommunitiesListViewModel : ViewModelBase, ILazyLoadData
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

        private bool IsLoaded { get; set; }

        private bool IsDataLoaded { get; set; }

        private bool IsReloadData { get; set; }

        private LM_CommunitiesList _loc = new LM_CommunitiesList();
        public LM_CommunitiesList LOC
        {
            get => _loc;
            set
            {
                _loc = value;
                OnPropertyChanged(() => LOC);
            }
        }

        private DataTable TempDataTable { get; set; }
        private ICollection<CommunitiesListModel> _objectsRightsItemSource;
        public ICollection<CommunitiesListModel> ObjectsRightsItemSource
        {
            get => _objectsRightsItemSource;
            set
            {
                _objectsRightsItemSource = value;


                if (InternalCommunity.InternalCommunityInfo == null)
                {
                    var i = _objectsRightsItemSource?.SingleOrDefault(rec => rec.IsMy == 1);
                    InternalCommunity.InternalCommunityInfo = new CommunityListView
                    {
                        CustId = i.CustId,
                        Name = i.Name,
                        InnerCode = i.InnerCode,
                        InterCode = i.InterCode,
                        RegistrDate = i.RegistrDate,
                        IsMy = i.IsMy,
                        CountAuthors = i.CountAuthors,
                    };
                }

                OnPropertyChanged(() => ObjectsRightsItemSource);
            }
        }

        #endregion

        #region * * * METHODS * * *

        private async Task LoadData(SearchModuleResource searchModuleResource)
        {
            var service = CommunityService.GetInstance();
            IsBusy = true;
            var data = await service.GetCommunitiesList(searchModuleResource);

            if (data.IsSuccess)
            {
                if (TempDataTable == null || IsReloadData)
                    TempDataTable = data.Data;

                ObjectsRightsItemSource = await Task.Factory.StartNew(() => ConvertToInternalModel(data.Data));
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

        private async void RunSearchDelegateMethod(SearchModuleResource searchModuleResource)
        {
            // wrap
            await LoadData(searchModuleResource);
        }

        private List<CommunitiesListModel> ConvertToInternalModel(DataTable dataTable)
        {
            var itemSource = new List<CommunitiesListModel>();

            var DTH = new DataTableHelper(dataTable.Columns);

            foreach (DataRow row in dataTable.Rows)
            {
                var obj = row.ItemArray;

                var item = new CommunitiesListModel
                {
                    CustId = DTC.CastInt(DTH.GetObject(obj, nameof(CommunitiesListModel.CustId))),
                    InnerCode = DTC.Cast<string>(DTH.GetObject(obj, nameof(CommunitiesListModel.InnerCode))),
                    InterCode = DTC.Cast<string>(DTH.GetObject(obj, nameof(CommunitiesListModel.InterCode))),
                    Name = DTC.Cast<string>(DTH.GetObject(obj, nameof(CommunitiesListModel.Name))),
                    RegistrDate = DTC.Cast<DateTime?>(DTH.GetObject(obj, nameof(CommunitiesListModel.RegistrDate))),
                    CountAuthors = DTC.CastInt(DTH.GetObject(obj, nameof(CommunitiesListModel.CountAuthors))),
                    IsMy = DTC.CastByte(DTH.GetObject(obj, nameof(CommunitiesListModel.IsMy))),
                };

                itemSource.Add(item);
            }

            return itemSource;
        }

        private async void Clear()
        {
            IsBusy = true;
            ObjectsRightsItemSource = await Task.Factory.StartNew(() => ConvertToInternalModel(TempDataTable));
            IsBusy = false;
        }

        public void LazyLoadData()
        {
            if (IsDataLoaded)
                return;

            var task = LoadData(new SearchModuleResource());
            IsDataLoaded = true;
        }

        private async void UpdateData()
        {
            IsReloadData = true;
            await LoadData(new SearchModuleResource());
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            if (IsLoaded)
                return;

            var searchControl = ((CommunitiesListControl)o).searchControl;
            var config = IpsGlobal.FrameTaskDictionary.Single(rec => rec.FrameCode == 5).FrameParam;
            ((SearchControlViewModel)searchControl.DataContext).Config = config;
            ((SearchControlViewModel)searchControl.DataContext).RunSearchQuery = RunSearchDelegateMethod;
            ((SearchControlViewModel)searchControl.DataContext).Clear = Clear;
            ((SearchControlViewModel)searchControl.DataContext).UpdateData = UpdateData;

            AppLanguageLibrary.UpdateLanguageLocalization(LOC, nameof(AppLanguageLibrary.CurrentLanguage.CommunitiesListLD));

            IsLoaded = true;
        }

        public ICommand OpenCommunityCommand => new IPSDelegateCommand(OpenCommunityCommandExecute);
        private async void OpenCommunityCommandExecute(object o)
        {
            var item = (CommunitiesListModel) o;
            var service = CommunityService.GetInstance();

            Customer customer = null;
            List<CommunityAuthorsView> autors = null;
            IsBusy = true;
            await Task.Factory.StartNew(() =>
            {
                customer = service.GetComunity(item.CustId);
                autors = service.GetView<CommunityAuthorsView>(typeof(CommunityAuthorsView), "vTsk_1_ListRHCommunity", item.CustId, "cmCustId");
            });
            IsBusy = false;

            var cabinetForm = new CommunityCabinetForm(customer, autors);
            cabinetForm.SaveCustomer += (Customer c) =>
            {
                var result = service.SaveCommunity(c);
                if (result)
                    UpdateData();
                return result;
            };
            cabinetForm.SaveAgreementChanges += service.SaveAgreement;
            cabinetForm.UpdateCustomer += service.GetComunity;
            cabinetForm.ChangeStatusAgr += service.ChangeStatusAgr;
            cabinetForm.GetCommunityRightList += service.GetCommunityRightList;
            cabinetForm.GetTermsOfService += service.GetTermsOfService;
            cabinetForm.SaveCustCmRightLimitedRights += service.SaveCustCmRightLimitedRights;
            cabinetForm.SaveTermsOfServiceLimitedRights += service.SaveTermsOfServiceLimitedRights;
            cabinetForm.Show();
        }

        public ICommand CreateCommunityCommand => new IPSDelegateCommand(CreateCommunityCommandExecute);
        private void CreateCommunityCommandExecute(object o)
        {
            var service = CommunityService.GetInstance();

            var community = service.GetTemplateComunity();
            using (var communityForm = new CommunityForm(community))
            {
                if (communityForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var result = service.SaveCommunity(community);
                    ShowMessage.ShowInfoByResult(LOC.CREATE_COMM_SUCC_MSG, LOC.CREATE_COMM_ERR_MSG, result);
                    UpdateData();
                }
            }
        }

        #endregion
    }
}
