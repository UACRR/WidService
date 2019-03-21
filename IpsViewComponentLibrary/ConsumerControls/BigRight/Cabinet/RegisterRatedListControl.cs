using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.InternalControlsModel;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight.Cabinet
{
    public partial class RegisterRatedListControl : UserControl
    {
        private const string CreateRatedListSuccess = "Додано новий розрахунковий лист!";
        private const string CreateRatedListError = "Неможливо додати розрахунковий лист!";
        private const string ConfirmSpectacleSuccess = "Перелік вистав погоджено!";
        private const string ConfirmSpectacleError = "Неможливо погодити перелік вистав!";

        private const string DeleteRegisterRatedListQuestion = "Видалити обраний розрахунковий лист?";
        private const string DeleteRegisterRatedListSuccess = "Розрахунковий лист видалено!";
        private const string DeleteRegisterRatedListError = "Неможливо видалити розрахунковий лист!";

        private readonly GridStateRecorder _gridStateRecorder = new GridStateRecorder();
        private Customer _customer;
        private IList<RatedListSpectacleBigRightView> _payslipsSpectacleViews;
        public delegate IList<BigRightSpectacleView> GetSpectacleView(int custId);

        public event GetSpectacleView OnSpectacleViewNeed;
        public event SaveRegisterRatedListEventHandler OnSavePayslip;
        public event GetRegisterRatedList OnGetRegisterRatedList;
        public event GetRegisterItemsEventHandler OnRegisterItemListNeed;
        public event SaveAndReturnNewPeriodListEventHandler SavePariodCommandExecuted;
        public event ActionWithTwoId DeleteRegisterRatedList;
        public event EmptyEventHandler UpdateData;

        public delegate List<RatedListMusicDesignBigRightView> MusicDesingEventHandler();
        /// <summary>
        /// Виникає при потребі показати музичне оформлення
        /// </summary>
        public event MusicDesingEventHandler GetMusicDesing;

        public RegisterRatedListControl()
        {
            InitializeComponent();
            gvViewSpectacles.MasterTemplate.ShowChildViewCaptions = false;
            splitContainer.Splitters.First().NextNavigationButton.PropertyChanged += ExtensionUtils.NavigationButtonPropertyChanged;
            splitContainer.Splitters.First().NextNavigationButton.Visibility = ElementVisibility.Collapsed;
            splitContainer.Splitters.First().PrevNavigationButton.PropertyChanged += ExtensionUtils.NavigationButtonPropertyChanged;
            splitContainer.Splitters.First().PrevNavigationButton.Visibility = ElementVisibility.Visible;
            _gridStateRecorder.AddGrid(gvRegisterRatedListView);
        }

        private void SplitContainer_PanelCollapsing(object sender, RadSplitContainer.PanelCollapsingEventArgs e)
        {
            var splitter = splitContainer.Splitters.First();
            splitter.PrevNavigationButton.AngleTransform = 180f;
        }

        public void SetAndUpdateData(Customer customer, IList<RatedListMainBigRightView> registers, IList<RatedListSpectacleBigRightView> payslipsSpectacleViews)
        {
            _customer = customer;
            _payslipsSpectacleViews = payslipsSpectacleViews;
            ctrlHeaderInfo.DataSource = ViewsSingleton.ConsumerBigRightView;
            gvRegisterRatedListView.DataSource = registers;
            btnAcceptSpectacles.Enabled = registers.Any();
        }

        // додати новий розрахунковий лист
        private void btnCreateRegisterRatedList_Click(object sender, EventArgs e)
        {
            var ratedList = new RegisterRatedList
            {
                CreateDate = DateTime.Today,
                Status = 0,
            };
            var spectacles = OnSpectacleViewNeed?.Invoke(_customer.CustId);
            var addform = new RegisterRatedListForm(ScopeOfUseForm.Create, _customer, spectacles, ratedList);
            addform.SavePariodCommandExecuted += SavePariod_Need;

            if (addform.ShowDialog() == DialogResult.OK)
            {
                var result = OnSavePayslip?.Invoke(ratedList) ?? false;
                if (result)
                    UpdateData?.Invoke();
                MessageShow.ShowInfoByResult(CreateRatedListSuccess, CreateRatedListError, result);
            }
        }

        //погодити перелік вистав
        private void btnConfirmSpectacles_Click(object sender, EventArgs e)
        {
            if (!(gvRegisterRatedListView.CurrentRow?.DataBoundItem is RatedListMainBigRightView reg))
                return;

            var ratedlist = GetRatedList(reg);
            ratedlist.Status = 1;
            foreach (var item in ratedlist.Register)
                item.RgStatus = 2;

            var result = OnSavePayslip?.Invoke(ratedlist) ?? false;
            if (result)
                UpdateData?.Invoke();
            MessageShow.ShowInfoByResult(ConfirmSpectacleSuccess, ConfirmSpectacleError, result);
        }

        //кнопка оновлення даних
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData?.Invoke();
        }

        // кнопки грід
        private void gvRegisterRatedListView_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (!(e.Row?.DataBoundItem is RatedListMainBigRightView item))
                return;

            switch (e.Column?.FieldName)
            {
                case "editBtn":
                    EditOrViewButtonAction(item);
                    break;
                case "deleteBtn":
                    DeleteButtonAction(item);
                    break;
            }
        }

        /// <summary>
        /// Редагувати або переглянути розрахунковий лист
        /// </summary>
        /// <param name="item"></param>
        private void EditOrViewButtonAction(RatedListMainBigRightView item)
        {
            var ratedList = GetRatedList(item);
            var spectacles = OnSpectacleViewNeed?.Invoke(_customer.CustId);

            // edit
            if (item.Status == 0)
            {
                _gridStateRecorder.RecordState();
                var addform = new RegisterRatedListForm(ScopeOfUseForm.Edit, _customer, spectacles, ratedList);
                addform.SavePariodCommandExecuted += SavePariod_Need;
                if (addform.ShowDialog() == DialogResult.OK)
                {
                    var result = OnSavePayslip?.Invoke(ratedList) ?? false;
                    if (result)
                        UpdateData?.Invoke();

                    MessageShow.ShowInfoAfterChanges(result);
                }
                _gridStateRecorder.RestoreState();
            }
            // view
            else if (item.Status == 1)
            {
                var addform = new RegisterRatedListForm(ScopeOfUseForm.View, _customer, spectacles, ratedList);
                addform.ShowDialog();
            }
        }

        /// <summary>
        /// Видалити розрахунковий лист
        /// </summary>
        /// <param name="item">Результат обробки видалення</param>
        private void DeleteButtonAction(RatedListMainBigRightView item)
        {
            _gridStateRecorder.RecordState();
            // Status = 0 - дозвіл на видалення
            if (item.Status == 0 && MessageShow.ConfirmAction(DeleteRegisterRatedListQuestion) == DialogResult.Yes)
            {
                var result = DeleteRegisterRatedList?.Invoke(_customer.CustId, item.RmId) ?? false;
                if(result)
                    UpdateData?.Invoke();
                MessageShow.ShowInfoByResult(DeleteRegisterRatedListSuccess, DeleteRegisterRatedListError, result);
            }
            _gridStateRecorder.RestoreState();
        }

        private RegisterRatedList GetRatedList(RatedListMainBigRightView reg)
        {
            var customer = OnGetRegisterRatedList?.Invoke(_customer.CustId);
            var license = customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec?.LicClass == 1 && rec?.LicStatus == 2);
            var paidPeriod = license?.PaidPeriod?.SingleOrDefault(rec => rec?.PeriodId == reg?.PeriodId);
            var payslip = paidPeriod?.RegisterRatedList?.SingleOrDefault(rec => rec?.RmId == reg?.RmId);

            if (payslip == null) return payslip;
            foreach (var register in payslip.Register)
            {
                if (register?.RegId is int item)
                {
                    var registerItem =
                        OnRegisterItemListNeed?.Invoke(item); //TODO: виклик списку по rmID (оптимізація)
                    if (registerItem != null)
                        register.RegisterItem.Add(registerItem.FirstOrDefault());
                }
            }

            return payslip;
        }

        private List<PaidPeriod> SavePariod_Need(int id, List<PaidPeriod> e)
        {
            var result = SavePariodCommandExecuted?.Invoke(id, e);
            if(result != null)
                UpdateData?.Invoke();
            return result;
        }

        private void gvRegisterRatedListView_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (pageView.SelectedPage != pvSpectacle)
                pageView.SelectedPage = pvSpectacle;

            if (gvRegisterRatedListView.Rows.Count == 0 || gvRegisterRatedListView?.CurrentRow?.DataBoundItem == null)
            {
                gvViewSpectacles.DataSource = new List<ParentTemplate>();
                bsChildTemplate.DataSource = new List<ChildTemplate>();
                btnAcceptSpectacles.Enabled = false;
                return;
            }

            if (e.CurrentRow?.DataBoundItem is RatedListMainBigRightView ratedListView)
            {
                SetSpectacleViewGridDataSource(ratedListView.RmId);
                btnAcceptSpectacles.Enabled = ratedListView.Status == 0;
            }
        }

        private void SetSpectacleViewGridDataSource(int rmId)
        {
            var dicParent = new Dictionary<int, ParentTemplate>();
            var parentList = new List<ParentTemplate>();
            var childList = new List<ChildTemplate>();

            foreach (var item in _payslipsSpectacleViews.Where(rec => rec.RmId == rmId))
            {
                if (!dicParent.Keys.Contains((int)item.ObjId))
                {
                    var parent = new ParentTemplate
                    {
                        ObjId = (int)item.ObjId,
                        RegId = item.RegId,
                        ObjName = item.ItemName,
                        ActCode = item.ActCode,
                        AuthAmount = item.AuthAmount,
                        AuthRate = item.AuthRate,
                        MusicAmount = item.MusicAmount,
                        MusicRate = item.MusicRate,
                        AvanseRest = item.AvanseRest,
                        PrepaySumAuthor = item.PrepaySumAuthor,
                        Amount = item.RegAmount,
                        CountUse = item.CountUse,
                    };
                    dicParent.Add((int)parent.ObjId, parent);
                    parentList.Add(parent);
                }

                var addItem = new ChildTemplate
                {
                    CustId = item.CustId,
                    ObjId = item.ObjId,
                    AmountDistributed = item.AmountDistributed,
                    AvanseUsed = item.AvanseUsed,
                    NameRh = item.NameRh,
                    RoleName = item.RoleName,
                    RoleRate = item.RoleRate
                };

                childList.Add(addItem);
                
            }

            gvViewSpectacles.DataSource = parentList;
            bsChildTemplate.DataSource = childList;
        }

        private void UpdateMusicDesignData()
        {
            if (gvViewSpectacles?.CurrentRow?.DataBoundItem == null)
                return;

            if(!(gvViewSpectacles.CurrentRow.DataBoundItem is ParentTemplate source))
                source = ((GridViewRowInfo)((GridViewHierarchyRowInfo)gvViewSpectacles.CurrentRow).Parent)?.DataBoundItem as ParentTemplate;

            ctrlMusicDesignHeaderInfo.DataSource = source;

            var musicDesign = GetMusicDesing?.Invoke();
            var dataSource = musicDesign?.Where(r => r.RegId == source?.RegId).ToList();
            gvMusicDesignView.DataSource = dataSource ;
        }

        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageView.SelectedPage == pvMusicalDesign)
                UpdateMusicDesignData();
        }
    }
}
