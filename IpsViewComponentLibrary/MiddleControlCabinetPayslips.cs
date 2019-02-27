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
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetPayslips : UserControl
    {
        private Customer _customer;
        private MainGridConsumerBigRightView _bigRightView;
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

        public MiddleControlCabinetPayslips()
        {
            InitializeComponent();
            gvViewSpectacles.MasterTemplate.ShowChildViewCaptions = false;
            splitContainer.Splitters.First().NextNavigationButton.PropertyChanged += ExtensionUtils.NavigationButtonPropertyChanged;
            splitContainer.Splitters.First().NextNavigationButton.Visibility = ElementVisibility.Collapsed;
            splitContainer.Splitters.First().PrevNavigationButton.PropertyChanged += ExtensionUtils.NavigationButtonPropertyChanged;
            splitContainer.Splitters.First().PrevNavigationButton.Visibility = ElementVisibility.Visible;
        }
        private void SplitContainer_PanelCollapsing(object sender, RadSplitContainer.PanelCollapsingEventArgs e)
        {
            var splitter = splitContainer.Splitters.First();
            splitter.PrevNavigationButton.AngleTransform = 180f;
        }

        public void SetAndUpdateData(Customer customer, 
            MainGridConsumerBigRightView bigRightView,
            IList<RatedListMainBigRightView> registers, 
            IList<RatedListSpectacleBigRightView> payslipsSpectacleViews)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            _payslipsSpectacleViews = payslipsSpectacleViews;
            ctrlHeaderInfo.DataSource = _bigRightView;
            gvViewRl.DataSource = registers;
            btnAcceptSpectacles.Enabled = registers.Any();
        }

        //додавання нового р/р
        private void btnAddNewRl_Click(object sender, EventArgs e)
        {
            RegisterRatedList ratedList = new RegisterRatedList
            {
                CreateDate = DateTime.Today,
                Status = 0,
            };
            
            var addform = new PayslipsCrEdForm(FormType.Create, _customer, OnSpectacleViewNeed?.Invoke(_customer.CustId), ratedList)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            addform.SavePariodCommandExecuted += Addform_SavePariodCommandExecuted;
            if (addform.ShowDialog() == DialogResult.OK)
            {
                if(OnSavePayslip?.Invoke(ratedList) ?? false)
                {
                    ExtensionUtils.ShowInfoMessage("Додано новий розрахунковий лист!","Успішно", MessageBoxIcon.Information);
                    UpdateData?.Invoke();
                }
                else
                    ExtensionUtils.ShowInfoMessage("Неможливо додати розрахунковий лист!", "Помилка", MessageBoxIcon.Error);
            }
            else
                ratedList = null;

        }

        // кнопки грід
        private void gvViewRl_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e?.Row?.DataBoundItem is RatedListMainBigRightView row)
            {
                bool result = false;
                int? currentRow = null;
                switch (e?.Column?.FieldName)
                {
                    case "editBtn":
                        var payslip = GetRatedList(row);
                        if (row?.Status == 0) // edit
                        {
                            PayslipsCrEdForm addform = new PayslipsCrEdForm(FormType.Edit, _customer,
                                OnSpectacleViewNeed?.Invoke(_customer.CustId), payslip)
                            {
                                StartPosition = FormStartPosition.CenterParent
                            };
                            addform.SavePariodCommandExecuted += Addform_SavePariodCommandExecuted;
                            if (addform.ShowDialog() == DialogResult.OK)
                            {
                                result = OnSavePayslip?.Invoke(payslip) ?? false;
                                if (result)
                                {
                                    ExtensionUtils.ShowInfoMessage("Редагований розрахунковий лист збережено!", "Успішно", MessageBoxIcon.Information);
                                    currentRow = e.Row.Index;
                                }
                                else
                                    ExtensionUtils.ShowInfoMessage("Неможливо зберегти зміни!", "Помилка",
                                        MessageBoxIcon.Error);
                            }
                        }
                        else if (row?.Status == 1) // view
                        {
                            PayslipsCrEdForm addform = new PayslipsCrEdForm(FormType.View, _customer,
                                OnSpectacleViewNeed?.Invoke(_customer.CustId), payslip)
                            {
                                StartPosition = FormStartPosition.CenterParent
                            };
                            addform.ShowDialog();
                        }

                        break;
                    case "deleteBtn":
                        if (row?.Status == 0 && MessageBox.Show("Видалити обраний розрахунковий лист?", "Підтвердження",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            result = DeleteRegisterRatedList?.Invoke(_customer.CustId, row.RmId) ?? false;
                            if (result)
                                ExtensionUtils.ShowInfoMessage("Розрахунковий лист видалено!", "Успішно",
                                    MessageBoxIcon.Information);
                            else
                                ExtensionUtils.ShowInfoMessage("Неможливо видалити розрахунковий лист!", "Помилка",
                                    MessageBoxIcon.Error);
                        }

                        break;
                }
                if (result)
                {
                    UpdateData?.Invoke();
                    if(currentRow != null)
                        gvViewRl.CurrentRow = gvViewRl.Rows.SingleOrDefault(r => r.Index == currentRow);
                }
            }
        }

        private RegisterRatedList GetRatedList(RatedListMainBigRightView reg)
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

        private List<PaidPeriod> Addform_SavePariodCommandExecuted(int id, List<PaidPeriod> e)
        {
            var result = SavePariodCommandExecuted?.Invoke(id, e);
            if(result != null)
                UpdateData?.Invoke();
            return result;
        }

        private void gvViewRl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (pageView.SelectedPage != pvSpectacle)
                pageView.SelectedPage = pvSpectacle;

            if (gvViewRl.Rows.Count == 0 || gvViewRl?.CurrentRow?.DataBoundItem == null)
            {
                gvViewSpectacles.DataSource = new List<ParentTemplate>();
                bsChildTemplate.DataSource = new List<ChildTemplate>();
                btnAcceptSpectacles.Enabled = false;
                return;
            }

            if ((e?.CurrentRow?.DataBoundItem as RatedListMainBigRightView)?.RmId != null)
            {
                SetSpectacleViewGridDataSource(((RatedListMainBigRightView) e.CurrentRow.DataBoundItem).RmId);
                btnAcceptSpectacles.Enabled = ((RatedListMainBigRightView) e.CurrentRow.DataBoundItem).Status == 0;
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
                rec = ((GridViewRowInfo)((GridViewHierarchyRowInfo)gvViewSpectacles.CurrentRow).Parent).DataBoundItem as ParentTemplate;
            
            cName.TextValue = rec?.ItemName;
            cActCode.TextValue = rec?.ActCode.ToString();//_spectacleViews.SingleOrDefault(item => item.ObjId == rec?.ObjId)?.ActCode.ToString();
            cCountUse.TextValue = "";//rec?.ToString();
            cAmount.TextValue = rec?.RegAmount.ToString();
            cAuthorAmount.TextValue = rec?.AuthAmount.ToString();
            cAuthorRate.TextValue = rec?.AuthRate.ToString();

            var row = gvViewRl.CurrentRow.DataBoundItem as RatedListMainBigRightView;

            var musicd = _payslipsSpectacleViews
                .Where(r => r.RmId == row?.RmId)
                .FirstOrDefault(r => r.ObjId == rec?.ObjId);

            cMusAmount.TextValue = musicd?.MusicAmount.ToString();
            cMusRate.TextValue = musicd?.MusicRate.ToString();

            var musicDesign = GetMusicDesing?.Invoke();
            var source = musicDesign?.Where(r => r.RegId == rec?.RegId).ToList();
            gvMusicDesignView.DataSource = source;
        }

        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageView.SelectedPage == pvMusicalDesign)
                UpdateMusicDesignData();
        }

        //погодити перелік вистав
        private void btnAcceptSpectacles_Click(object sender, EventArgs e)
        {
            if (gvViewRl.CurrentRow.DataBoundItem is RatedListMainBigRightView reg)
            {
                var ratedlist = GetRatedList(reg);
                ratedlist.Status = 1;
                foreach (var item in ratedlist.Register)
                    item.RgStatus = 2;

                var result = OnSavePayslip?.Invoke(ratedlist) ?? false;
                if (result)
                {
                    ExtensionUtils.ShowInfoMessage("Перелік вистав погоджено!", "Успішно", MessageBoxIcon.Information);
                    UpdateData?.Invoke();
                }
                else
                    ExtensionUtils.ShowInfoMessage("Неможливо погодити перелік вистав!", "Помилка", MessageBoxIcon.Error);
            }
        }

        //кнопка оновлення даних
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData?.Invoke();
        }
    }
}
