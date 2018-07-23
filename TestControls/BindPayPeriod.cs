using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary;

namespace TestControls
{
    public partial class BindPayPeriod : UserControl
    {
        readonly ConsumerService _service = null;
        public BindPayPeriod(ConsumerService service)
        {
            _service = service;
            InitializeComponent();
            SetupDragDrop();

        }

        private void SetupDragDrop()
        {
            SubscribeForGridEvents( radGridView1, radGridView2);
            SubscribeForGridEvents( radGridView2, radGridView1);
        }



        private void SubscribeForGridEvents(RadGridView grid, RadGridView GridTarget)
        {
            RadDragDropService dragDropService = grid.GridViewElement.GetService<RadDragDropService>();
            dragDropService.PreviewDragOver += new EventHandler<RadDragOverEventArgs>(dragDropService_PreviewDragOver);
            dragDropService.PreviewDragDrop += new EventHandler<RadDropEventArgs>(dragDropService_PreviewDragDrop);
            dragDropService.PreviewDragStart += new EventHandler<PreviewDragStartEventArgs>(svc_PreviewDragStart);

            var behavior =  grid.GridBehavior as BaseGridBehavior;
            grid.GridBehavior = behavior;

            behavior.UnregisterBehavior(typeof(GridViewDataRowInfo));
            behavior.RegisterBehavior(typeof(GridViewDataRowInfo), new RowSelectionGridBehavior(GridTarget));

        }


        #region Drag & drop logic

        private void svc_PreviewDragStart(object sender, PreviewDragStartEventArgs e)
        {
            e.CanStart = true;
        }

        private void dragDropService_PreviewDragDrop(object sender, RadDropEventArgs e)
        {
            RadItem dropTarget = e.HitTarget as RadItem;
            if (dropTarget == null)
                return;
            RadGridView targetGrid = dropTarget.ElementTree.Control as RadGridView;

            dropTarget = (RadItem)e.DragInstance;
            if (dropTarget == null)
                return;
            //var sourceGrid = dropTarget.ElementTree.Control as RadGridView;

            //var targetRow = targetGrid.CurrentRow.DataBoundItem;
            //var sourceRow = sourceGrid.CurrentRow.DataBoundItem;

            //var pay = targetRow is MoneyReceived @item1 ? @item1 : sourceRow as MoneyReceived;
            //var lic = targetRow is LicenseAgrParam @item2 ? @item2 : sourceRow as LicenseAgrParam;

            //DistributionForm form = new DistributionForm(pay, lic.Lic);

            //if(form.ShowDialog() == DialogResult.OK )
            //{

            //}
            Task.Run(()=>radButton2.PerformClick());
            e.Handled = true;


            

        }

        private void dragDropService_PreviewDragOver(object sender, RadDragOverEventArgs e)
        {
            if (e.DragInstance is GridDataRowElement && e.HitTarget is GridDataRowElement )
            {
                RadItem dropTarget = e.HitTarget as RadItem;
                RadGridView targetGrid = dropTarget.ElementTree.Control as RadGridView;

                //var behavior = targetGrid.GridBehavior  as BaseGridBehavior;
                //var rowViewBehavior = behavior.GetBehavior(typeof(GridViewDataRowInfo)) as RowSelectionGridBehavior;

                dropTarget = (RadItem)e.DragInstance;
                var sourceGrid = dropTarget.ElementTree.Control as RadGridView; ;
                var rowViewSorceBehavior = ((BaseGridBehavior)sourceGrid.GridBehavior).GetBehavior(typeof(GridViewDataRowInfo)) as RowSelectionGridBehavior;



                if (rowViewSorceBehavior == null || rowViewSorceBehavior.Target != targetGrid )
                    return;


                e.CanDrop = (e.HitTarget is GridDataRowElement ||
                            e.HitTarget is GridTableElement ||
                            e.HitTarget is GridSummaryRowElement);
            }
        }

        private void dragDropService_PreviewDragHint(object sender, PreviewDragHintEventArgs e)
        {
            SnapshotDragItem dragInstance = e.DragInstance as SnapshotDragItem;

            if (dragInstance == null)
            {
                return;
            }

            GridViewRowInfo rowInfo = e.DragInstance.GetDataContext() as GridViewRowInfo;

            if (rowInfo != null && rowInfo.ViewTemplate.MasterTemplate.SelectedRows.Count > 1)
            {
                //e.DragHint = new Bitmap(this.imageList1.Images[6]);
                //e.UseDefaultHint = false;
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

                BindAllSum();
                BindLicAgreements();

                SetGrid3DataSource();
                SetGrid4DataSource();
            }

        }

        private void BindLicAgreements()
        {
            var licAgr = _customer.Client.LicenseAgreement.Select(rec => rec.LicenseAgrParam.Single(item => item.LicVersion == rec.LicVersion));
            if (licAgr.Count() > 0)
                LicAgreementBindingSource.DataSource = licAgr;
            else
                LicAgreementBindingSource.DataSource = typeof(LicenseAgrParam);
        }

        private void BindAllSum()
        {
            var list = _customer.Client.MoneyReceived.Where(rec => rec.Amount > (rec.DestribAmount + rec.DestribPrepay));
            // radGridView1.RowCount = list.Count();
            if (list.Count() == 0)
            {
                AllmoneyReceivedBindingSource.DataSource = typeof(MoneyReceived);
            }
            else
                AllmoneyReceivedBindingSource.DataSource = list;
        }

        private void radGridView2_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            SetGrid3DataSource();
        }

        private void radGridView3_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            SetGrid4DataSource();
        }

        // Period
        private void SetGrid3DataSource()
        {
            if (radGridView2.CurrentRow != null)
            {
                var licItem = (LicenseAgrParam)radGridView2.CurrentRow.DataBoundItem;
                paidPeriodBindingSource.DataSource = licItem.Lic.PaidPeriod.OrderBy(rec => rec.BeginDate ).ToList();
            }
            else
            {
                paidPeriodBindingSource.DataSource = typeof(PaidPeriod);
            }
        }
        //PeriodMoney
        private void SetGrid4DataSource()
        {
            if (radGridView3.CurrentRow != null)
            {
                var paydItem = (PaidPeriod)radGridView3.CurrentRow.DataBoundItem;

                PeriodMoneyReceivedBindingSource.DataSource = paydItem.MoneyPeriodLink;
            }
            else
            {
                PeriodMoneyReceivedBindingSource.DataSource = typeof(MoneyPeriodLink);
            }
        }




        private void radButton1_Click(object sender, EventArgs e)
        {
            var currentAgree = radGridView2.CurrentRow.DataBoundItem as LicenseAgrParam;
            CreatePeriod dialog = new CreatePeriod(currentAgree);

            if( dialog.ShowDialog() == DialogResult.OK )
            {
                _service.SavePeriods((int)currentAgree.Lic.CustId, currentAgree.Lic.PaidPeriod.ToList());

                SetGrid3DataSource();
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            MoneyReceived pay = radGridView1.CurrentRow.DataBoundItem as MoneyReceived;
            var licParam = radGridView2.CurrentRow.DataBoundItem as LicenseAgrParam;
            if (licParam?.Lic == null || pay == null)
                return;
            DistributionForm form = new DistributionForm( pay, licParam.Lic );

            if(form.ShowDialog() == DialogResult.OK )
            {
                MessageBox.Show("!!! Ok !!!");
            }
        }

        private void radGridView2_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            var ri = e.RowElement.RowInfo;
            var licAgreement = (LicenseAgrParam)ri.DataBoundItem;

            var debt = licAgreement.Lic.PaidPeriod.Sum(rec => rec.Amount - rec.Distribamount - rec.Undistribamount);
            ri.Cells["Debt"].Value = Convert.ToDecimal(debt < 0 ? 0 : debt);
        }
    }
}
