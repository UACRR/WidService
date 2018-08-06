using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary
{
    public partial class CalculationInfoControl : UserControl
    {

        public event EventHandler<List<PaidPeriod>> SavePariodCommandExecuted;
        public event EventHandler<List<MoneyPeriodLink>> SaveLinkCommandExecuted;
        public event EventHandler<PaidPeriod> SetPeriodStateExecuted;

        public delegate void UpdateCustomerDataEventHandler(int id);
        public event UpdateCustomerDataEventHandler UpdateData;
        private GridDataRowElement dragRow;
        private GridDataRowElement dropRow;
        private ButtonController buttonController;

        public CalculationInfoControl()
        {
            InitializeComponent();
            SetupDragDrop();

            buttonController = new ButtonController(btnNewPeriod, btnDistribute, btnClosePeriod);

        }

        private void SetupDragDrop()
        {
            SubscribeForGridEvents(gvUserMoneys, gvLicenseAgr);
            SubscribeForGridEvents(gvLicenseAgr, gvUserMoneys);
            SubscribeForGridEvents(gvPeriodsPayment, gvUserMoneys);
        }



        private void SubscribeForGridEvents(RadGridView grid, RadGridView GridTarget)
        {
            RadDragDropService dragDropService = grid.GridViewElement.GetService<RadDragDropService>();
            dragDropService.PreviewDragOver += new EventHandler<RadDragOverEventArgs>(dragDropService_PreviewDragOver);
            dragDropService.PreviewDragDrop += new EventHandler<RadDropEventArgs>(dragDropService_PreviewDragDrop);
            dragDropService.PreviewDragStart += new EventHandler<PreviewDragStartEventArgs>(svc_PreviewDragStart);

            var behavior = grid.GridBehavior as BaseGridBehavior;
            grid.GridBehavior = behavior;

            behavior.UnregisterBehavior(typeof(GridViewDataRowInfo));
            behavior.RegisterBehavior(typeof(GridViewDataRowInfo), new RowSelectionGridBehavior(GridTarget));

        }


        #region Drag & drop logic *****************************************************************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void svc_PreviewDragStart(object sender, PreviewDragStartEventArgs e)
        {
            e.CanStart = true;
            RadItem target = e.DragInstance as RadItem;
            var row = target as GridDataRowElement;

            dragRow = row;
            dropRow = null;

        }

        List<KeyValuePair<Type, Type>> validDragDrop = new List<KeyValuePair<Type, Type>>
        {
            new KeyValuePair<Type, Type>( typeof( MoneyReceived), typeof(LicenseAgrParam )),
            new KeyValuePair<Type, Type>( typeof( MoneyReceived), typeof(PaidPeriod )),
            new KeyValuePair<Type, Type>( typeof(PaidPeriod ), typeof( MoneyReceived)),
            new KeyValuePair<Type, Type>( typeof(LicenseAgrParam ), typeof( MoneyReceived)),
        };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dragDropService_PreviewDragDrop(object sender, RadDropEventArgs e)
        {
            RadItem dropTarget = e.HitTarget as RadItem;
            if (dropTarget == null)
                return;

            RadGridView targetGrid = dropTarget.ElementTree.Control as RadGridView;
            var dropTargetRow = dropTarget as GridDataRowElement;
            dropRow = dropTargetRow;

            KeyValuePair<Type, Type> search = new KeyValuePair<Type, Type>(dragRow.RowInfo.DataBoundItem.GetType(), dropRow.RowInfo.DataBoundItem.GetType());
            if (!validDragDrop.Contains(search))
                return;

            boolRunFromDragDrop = true;
            e.Handled = true;

            btnDistribute.BeginInvoke((Action)(() =>
            {
                btnDistribute.PerformClick();
            }));
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dragDropService_PreviewDragOver(object sender, RadDragOverEventArgs e)
        {
            if (e.DragInstance is GridDataRowElement && e.HitTarget is GridDataRowElement)
            {
                RadItem dropTarget = e.HitTarget as RadItem;
                RadGridView targetGrid = dropTarget.ElementTree.Control as RadGridView;
                GridDataRowElement hitRow = dropTarget as GridDataRowElement;

                if (hitRow.RowInfo.DataBoundItem.GetType() == dragRow.RowInfo.DataBoundItem.GetType())
                    return;

                KeyValuePair<Type, Type> search = new KeyValuePair<Type, Type>(dragRow.RowInfo.DataBoundItem.GetType(), hitRow.RowInfo.DataBoundItem.GetType());
                e.CanDrop = validDragDrop.Contains(search);

            }
        }



        #endregion


        /// <summary>
        /// 
        /// </summary>

        /// <summary>
        /// 
        /// </summary>
        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                if (_customer == null)
                {
                    AllmoneyReceivedBindingSource.DataSource = typeof(MoneyReceived);
                    LicAgreementBindingSource.DataSource = typeof(LicenseAgrParam);
                    return;
                }

                normalizeData(_customer);
                SetupAllBinding();
            }

        }

        private void normalizeData(Customer cust)
        {
            var dicType = IpsGlobal.AnketaDictionaties.agrLicenseType.ToDictionary(rec => rec.CodeI);
            var dicStatus = IpsGlobal.AnketaDictionaties.agreementStatus.ToDictionary(rec => rec.CodeI);
            var dicPeriod = IpsGlobal.AnketaDictionaties.period.ToDictionary(rec => rec.CodeI);
            var dicPeriodStatus = IpsGlobal.AnketaDictionaties.periodStatus.ToDictionary(rec => rec.CodeI);

            foreach (var item in cust.Client.LicenseAgreement)
            {
                item.LicCodeNavigation = dicType[item.LicType ?? 1];

                foreach (var licParam in item.LicenseAgrParam)
                {
                    licParam.Lic = item;
                    licParam.LicStatusNavigation = dicStatus[licParam.LicStatus ?? 1];
                    licParam.PeriodCodeNavigation = dicPeriod[licParam.PeriodCode ?? 1];
                }
                foreach (var period in item.PaidPeriod)
                {
                    period.StatusNavigation = dicPeriodStatus[period.Status];
                    period.Lic = item;
                    foreach (var link in period.MoneyPeriodLink)
                        link.Period = period;
                }
            }
        }

        private void BindLicAgreements()
        {
            var licAgr = _customer.Client.LicenseAgreement.Where(rec => rec.LicStatus == 2).Select(rec => rec.LicenseAgrParam.SingleOrDefault(item => item.LicVersion == rec.LicVersion && rec.LicStatus == 2)).ToList();
            if (licAgr.Count() > 0)
                LicAgreementBindingSource.DataSource = licAgr?.Where( rec => rec?.LicStatus == 2);
            else
                LicAgreementBindingSource.DataSource = typeof(LicenseAgrParam);
        }

        private void BindAllSum()
        {
            var list = _customer.Client.MoneyReceived.Where(rec => rec.Amount > (rec.DestribAmount + rec.DestribPrepay));
            if (list.Count() == 0)
            {
                AllmoneyReceivedBindingSource.DataSource = typeof(MoneyReceived);
            }
            else
                AllmoneyReceivedBindingSource.DataSource = list;
        }

        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            SetGrid3DataSource();
        }


        // Period
        private void SetGrid3DataSource()
        {
            if (gvLicenseAgr.CurrentRow != null)
            {
                var licItem = (LicenseAgrParam)gvLicenseAgr.CurrentRow.DataBoundItem;
                paidPeriodBindingSource.DataSource = licItem.Lic?.PaidPeriod.Where(rec => rec.Status < 7).OrderBy(rec => rec.BeginDate).ToList();
            }
            else
            {
                paidPeriodBindingSource.DataSource = typeof(PaidPeriod);
            }
        }




        private void radButton1_Click(object sender, EventArgs e)
        {
            var currentAgree = gvLicenseAgr.CurrentRow.DataBoundItem as LicenseAgrParam;
            CreatePeriod dialog = new CreatePeriod(currentAgree);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SavePariodCommandExecuted(this, currentAgree.Lic.PaidPeriod.ToList());
                UpdateData?.Invoke(_customer.CustId);
                SetupAllBinding();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        bool boolRunFromDragDrop = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtnDistribute_Click(object sender, EventArgs e)
        {

            MoneyReceived pay = null;
            LicenseAgrParam licParam = null;
            PaidPeriod period = null;
            if (boolRunFromDragDrop)
            {

                GridDataRowElement payRow = null,
                                   destRow = null;

                if (dragRow.RowInfo.DataBoundItem is MoneyReceived)
                {
                    payRow = dragRow;
                    destRow = dropRow;
                }
                else
                {
                    payRow = dropRow;
                    destRow = dragRow;
                }

                pay = payRow.RowInfo.DataBoundItem as MoneyReceived;
                if (destRow.RowInfo.DataBoundItem is PaidPeriod) // Drop to PaidPeriod
                {
                    period = destRow.RowInfo.DataBoundItem as PaidPeriod;

                    licParam = period.Lic.LicenseAgrParam.Single(rec => rec.LicVersion == period.Lic.LicVersion);

                }
                else // Drop to LicenceAgreement
                {
                    licParam = destRow.RowInfo.DataBoundItem as LicenseAgrParam;
                    period = null;

                }

                boolRunFromDragDrop = false;
            }
            else
            {
                if (gvUserMoneys.CurrentRow == null || gvLicenseAgr.CurrentRow == null)
                    return;

                pay = gvUserMoneys.CurrentRow.DataBoundItem as MoneyReceived;
                licParam = gvLicenseAgr.CurrentRow.DataBoundItem as LicenseAgrParam;
                period = gvPeriodsPayment.CurrentRow.DataBoundItem as PaidPeriod;

            }

            if (licParam?.Lic == null || pay == null)
                return;


            DistributionForm form = new DistributionForm(pay, licParam.Lic, period);

            if (form.ShowDialog() == DialogResult.OK)
            {
                List<MoneyPeriodLink> ListLink = new List<MoneyPeriodLink>();
                foreach (var item in licParam.Lic.PaidPeriod)
                {
                    var itemList = item.MoneyPeriodLink;
                    ListLink.AddRange(itemList);

                }

                SaveLinkCommandExecuted(this, ListLink);
                foreach (var item in ListLink)
                {
                    var payCustomer = _customer.Client.MoneyReceived.SingleOrDefault(rec => rec.PaidId == item.PaidId);
                    if (payCustomer != null)
                        payCustomer.DestribAmount = item.Paid.DestribAmount;
                }
                //SetupAllBinding();
                RefreshData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshData()
        {
            gvPeriodsPayment.MasterTemplate.Refresh();
            gvLicenseAgr.MasterTemplate.Refresh();
            gvUserMoneys.MasterTemplate.Refresh();
        }

        private void SetupAllBinding()
        {

            BindAllSum();
            BindLicAgreements();

            SetGrid3DataSource();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvLicenseAgr_RowFormatting(object sender, RowFormattingEventArgs e)
        {

            var ri = e.RowElement?.RowInfo;
            var licAgreement = (LicenseAgrParam)ri?.DataBoundItem;

            var debt = licAgreement.Lic.PaidPeriod.Where(rec => rec.EndDate <= DateTime.Today).Sum(rec =>
            {
                return Math.Max(0, rec.Amount - (rec.Distribamount + rec.Undistribamount));
                ;
            });
            ri.Cells["Debt"].Value = Convert.ToDecimal(debt);
        }

        /// Закрити період
        private void btnClosePeriod_Click(object sender, EventArgs e)
        {
            var period = gvPeriodsPayment.CurrentRow?.DataBoundItem as PaidPeriod;
            if (period == null)
                return;

            if (MessageBox.Show($"Закрити період {period.PeriodName} ?", "Закриття періоду", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                period.Status = 7;
                SetPeriodStateExecuted?.Invoke(this, period);
                paidPeriodBindingSource.RemoveCurrent();
                RefreshData();
            }
        }

        private void gvPeriodsPayment_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            buttonController.changePeriod(e.CurrentRow?.DataBoundItem as PaidPeriod);
        }
    }

    class ButtonController
    {
        private RadButton _btnNewPeriod,
                            _btnDistribute,
                            _btnClosePeriod;
        public ButtonController(RadButton btnNewPeriod, RadButton btnDistribute, RadButton btnClosePeriod)
        {
            _btnNewPeriod = btnNewPeriod;
            _btnDistribute = btnDistribute;
            _btnClosePeriod = btnClosePeriod;
        }

        public void changePeriod(PaidPeriod period)
        {
            if (period == null
                || period.Amount > period.Distribamount + period.Undistribamount)
                _btnClosePeriod.Enabled = false;
            else
                _btnClosePeriod.Enabled = true;
        }
    }

    public class GridLicAgr
    {
        public int Id { get; set; }
        public int LicenseId { get; set; }
        public string License { get; set; }
        public string Series { get; set; }
        public string AgrNumber { get; set; }
        public string DateBegin { get; set; }
        public string DateEnd { get; set; }
        public decimal Amount { get; set; }
        public string State { get; set; }
        public string PeriodPayment { get; set; }
        public decimal Debt { get; set; }
    }
    public class GridPeriods
    {
        //public int LicId { get; set; }

        public int PeriodId { get; set; }

        public string PeriodName { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountBound { get; set; }
        // public decimal Undistribamount { get; set; }
        public decimal DistAmount { get; set; }
        public decimal Arrears { get; set; }
        public bool AutoSet { get; set; }
    }

    public class GridPayments
    {
        public int PaidId { get; set; }
        public string SelectPeriod { get; set; }
        public string DateInvoice { get; set; }
        public string NumberInvoice { get; set; }
        public string GoalInvoice { get; set; }
        public decimal Amount { get; set; }
        public decimal DestribAmount { get; set; }
    }
}
