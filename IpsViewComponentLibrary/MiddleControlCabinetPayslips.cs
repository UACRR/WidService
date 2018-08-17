using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetPayslips : UserControl
    {
        private Customer _customer;
        private ConsumerBigRightView _bigRightView;
        private IList<BigRightPayslipsSpectacleView> _payslipsSpectacleViews;

        public delegate IList<BigRightSpectacleView> GetSpectacleView(int custId);

        public event GetSpectacleView OnSpectacleViewNeed;
        public event SavePayslipsEventHandler OnSavePayslip;
        public event GetRegisterRatedList OnGetRegisterRatedList;
        public event GetRegisterItemsEventHandler OnRegisterItemListNeed;
        public event EventHandler<List<PaidPeriod>> SavePariodCommandExecuted;

        public delegate List<MusicDesignRatedListView> MusicDesingDelegate();
        public MusicDesingDelegate MusicDesing { get; set; }

        public MiddleControlCabinetPayslips()
        {
            InitializeComponent();
            gvViewSpectacles.MasterTemplate.ShowChildViewCaptions = false;
        }

        public void SetAndUpdateData(Customer customer, 
            ConsumerBigRightView bigRightView,
            IList<BigRightRegister> registers, 
            IList<BigRightPayslipsSpectacleView> payslipsSpectacleViews)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            _payslipsSpectacleViews = payslipsSpectacleViews;
            ctrlHeaderInfo.DataSource = _bigRightView;
            gvViewRl.DataSource = registers;

        }

        //додавання нового р/р
        private void btnAddNewRl_Click(object sender, EventArgs e)
        {
            RegisterRatedList ratedList = new RegisterRatedList
            {
                CreateDate = DateTime.Today,
                Status = 0,
            };
            
            PayslipsCrEdForm addform = new PayslipsCrEdForm(FormType.Create, _customer, OnSpectacleViewNeed?.Invoke(_customer.CustId), ratedList);
            if (addform.ShowDialog() == DialogResult.OK)
            {
                if(OnSavePayslip?.Invoke(ratedList) ?? false)
                    ExtensionUtils.ShowInfoMessage("Додано новий розрахунковий лист!","Успішно", MessageBoxIcon.Information);
            }
            else
                ratedList = null;

        }

        //видалення р/р
        private void btnDeleteRl_Click(object sender, EventArgs e)
        {

        }

        //редагування р/р
        private void gvViewRl_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var row = e?.Row?.DataBoundItem as BigRightRegister;
            btnToAccept.Enabled = row?.Status == 0;
            if (row?.Status == 1)
                return;
            

            var payslip = GetRatedList(row);

            PayslipsCrEdForm addform = new PayslipsCrEdForm(FormType.Edit, _customer, OnSpectacleViewNeed?.Invoke(_customer.CustId), payslip)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addform.SavePariodCommandExecuted += Addform_SavePariodCommandExecuted;
            if (addform.ShowDialog() == DialogResult.OK)
            {
                if (OnSavePayslip?.Invoke(payslip) ?? false)
                    ExtensionUtils.ShowInfoMessage("Редагований розрахунковий лист збережено!", "Успішно",
                        MessageBoxIcon.Information);
                else
                    ExtensionUtils.ShowInfoMessage("Неможливо зберегти зміни!", "Помилка", MessageBoxIcon.Error);
            }
        }

        private RegisterRatedList GetRatedList(BigRightRegister reg)
        {
            var customer = OnGetRegisterRatedList?.Invoke(_customer.CustId);
            var license = customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec?.LicClass == 1 && rec?.LicStatus == 2);
            var paidPeriod = license?.PaidPeriod?.SingleOrDefault(rec => rec?.PeriodId == reg?.PeriodId);
            var payslip = paidPeriod?.RegisterRatedList?.SingleOrDefault(rec => rec?.RmId == reg?.RmId);

            if (payslip != null)
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

        private void Addform_SavePariodCommandExecuted(object sender, List<PaidPeriod> e)
        {
            SavePariodCommandExecuted?.Invoke(sender, e);
        }

        private void gvViewRl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvViewRl.Rows.Count == 0 || gvViewRl?.CurrentRow?.DataBoundItem == null) return;

            if (collapsiblePanel.IsExpanded && (e?.CurrentRow?.DataBoundItem as BigRightRegister)?.RmId != null)
            {
                SetSpectacleViewGridDataSource(((BigRightRegister) e.CurrentRow.DataBoundItem).RmId);
                if(pageView.SelectedPage != pvSpectacle)
                    pageView.SelectedPage = pvSpectacle;
            }
        }

        private void SetSpectacleViewGridDataSource(int rmId)
        {
            Dictionary<int, ParentTemplate> dicParent = new Dictionary<int, ParentTemplate>();

            List<ParentTemplate> parentList = new List<ParentTemplate>();
            List<ChildTemplate> childList = new List<ChildTemplate>();

            foreach (var item in _payslipsSpectacleViews.Where(rec => rec.RmId == rmId))
            {
                ParentTemplate parent = null;
                if (!dicParent.Keys.Contains((int)item.ObjId))
                {
                    parent = new ParentTemplate
                    {
                        ObjId = (int)item.ObjId,
                        RegId = item.RegId,
                        ItemName = item.ItemName,
                        ActCode = item.ActCode,
                        AuthAmount = item.AuthAmount,
                        AuthRate = item.AuthRate,
                        AvanseRest = item.AvanseRest,
                        PrepaySumAuthor = item.PrepaySumAuthor,
                        RegAmount = item.RegAmount,
                    };
                    dicParent.Add( (int)parent.ObjId, parent);
                    parentList.Add(parent);
                }

                ChildTemplate addItem = new ChildTemplate
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
            if (gvViewSpectacles.Rows.Count == 0) return;

            if(!(gvViewSpectacles.CurrentRow.DataBoundItem is ParentTemplate rec))
                rec = ((Telerik.WinControls.UI.GridViewRowInfo)((Telerik.WinControls.UI.GridViewHierarchyRowInfo)gvViewSpectacles.CurrentRow).Parent).DataBoundItem as ParentTemplate;
            
            cName.TextValue = rec?.ItemName;
            cActCode.TextValue = rec?.ActCode.ToString();//_spectacleViews.SingleOrDefault(item => item.ObjId == rec?.ObjId)?.ActCode.ToString();
            cCountUse.TextValue = "";//rec?.ToString();
            cAmount.TextValue = rec?.RegAmount.ToString();
            cAuthorAmount.TextValue = rec?.AuthAmount.ToString();
            cAuthorRate.TextValue = rec?.AuthRate.ToString();

            var row = gvViewRl.CurrentRow.DataBoundItem as BigRightRegister;

            var musicd = _payslipsSpectacleViews
                .Where(r => r.RmId == row?.RmId)
                .FirstOrDefault(r => r.ObjId == rec?.ObjId);

            cMusAmount.TextValue = musicd?.MusicAmount.ToString();
            cMusRate.TextValue = musicd?.MusicRate.ToString();

            var musicDesign = MusicDesing?.Invoke();
            var source = musicDesign?.Where(r => r.RegId == rec?.RegId).ToList();
            gvMusicDesignView.DataSource = source;
        }

        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageView.SelectedPage == pvMusicalDesign)
                UpdateMusicDesignData();
        }

        private void btnToAccept_Click(object sender, EventArgs e)
        {
            if(gvViewRl.CurrentRow.DataBoundItem is BigRightRegister reg)
            {
                var ratedlist = GetRatedList(reg);
                ratedlist.Status = 1;
                foreach (var item in ratedlist.Register)
                    item.RgStatus = 2;
                
                var result = OnSavePayslip?.Invoke(ratedlist) ?? false;
                if (result)
                    ExtensionUtils.ShowInfoMessage("Перелік вистав погоджено!", "Успішно", MessageBoxIcon.Information);
                else
                    ;
            }
        }
    }
}
