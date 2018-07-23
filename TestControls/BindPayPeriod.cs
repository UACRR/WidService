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
            SubscribeForGridEvents( radGridView1, typeof(ExternalPay));
            SubscribeForGridEvents( radGridView2, typeof(LicenseAgrParam));
        }



        private void SubscribeForGridEvents(RadGridView grid, Type GridType)
        {
            RadDragDropService dragDropService = grid.GridViewElement.GetService<RadDragDropService>();
            dragDropService.PreviewDragOver += new EventHandler<RadDragOverEventArgs>(dragDropService_PreviewDragOver);
            dragDropService.PreviewDragDrop += new EventHandler<RadDropEventArgs>(dragDropService_PreviewDragDrop);
            //dragDropService.PreviewDragHint += new EventHandler<PreviewDragHintEventArgs>(dragDropService_PreviewDragHint);
            dragDropService.PreviewDragStart += new EventHandler<PreviewDragStartEventArgs>(svc_PreviewDragStart);

            // grid.CellFormatting += new CellFormattingEventHandler(grid_CellFormatting);
            ////            grid.Rows.CollectionChanged += new Telerik.WinControls.Data.NotifyCollectionChangedEventHandler(Rows_CollectionChanged);

            // grid.RowFormatting += Grid_RowFormatting;
            var behavior = new CustomGridBehavior(GridType);
            grid.GridBehavior = behavior;

            behavior.UnregisterBehavior(typeof(GridViewDataRowInfo));
            behavior.RegisterBehavior(typeof(GridViewDataRowInfo), new RowSelectionGridBehavior());


        }

        private void Grid_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            e.RowElement.AllowDrag = true;
            e.RowElement.AllowDrop = true;
        }


        #region Drag & drop logic

        private void svc_PreviewDragStart(object sender, PreviewDragStartEventArgs e)
        {
            e.CanStart = true;
        }

        private void dragDropService_PreviewDragDrop(object sender, RadDropEventArgs e)
        {
            SnapshotDragItem dragInstance = e.DragInstance as SnapshotDragItem;

            if (dragInstance == null)
            {
                return;
            }

            RadItem dropTarget = e.HitTarget as RadItem;
            RadGridView targetGrid = dropTarget.ElementTree.Control as RadGridView;

            if (targetGrid == null)
            {
                return;
            }

            RadGridView dragGrid = dragInstance.Item.ElementTree.Control as RadGridView;

            if (targetGrid != dragGrid)
            {
                e.Handled = true;

//                CustomGridBehavior behavior = (CustomGridBehavior)dragGrid.GridBehavior;
                GridDataRowElement dropTargetRow = dropTarget as GridDataRowElement;
//                this.MoveRows(targetGrid, dragGrid, behavior.SelectedRows, index);
            }
        }

        private void dragDropService_PreviewDragOver(object sender, RadDragOverEventArgs e)
        {
            if (e.DragInstance is GridDataRowElement && e.HitTarget is GridDataRowElement )
            {
                RadItem dropTarget = e.HitTarget as RadItem;
                RadGridView targetGrid = dropTarget.ElementTree.Control as RadGridView;
                RowSelectionGridBehavior behavior = (RowSelectionGridBehavior)targetGrid.GridBehavior;


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
                paidPeriodBindingSource.DataSource = licItem.Lic.PaidPeriod;
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


        private void MasterTemplate_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.Name == "Debt")
            {
                var licAgreement = (LicenseAgrParam)e.Row.DataBoundItem;

                var debt = licAgreement.Lic.PaidPeriod.Sum(rec => rec.Amount - rec.Distribamount - rec.Undistribamount);
                e.CellElement.Text = Convert.ToDecimal(debt < 0 ? 0 : debt).ToString();
            }

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            var currentAgree = radGridView2.CurrentRow.DataBoundItem as LicenseAgrParam;
            CreatePeriod dialog = new CreatePeriod(currentAgree);

            if( dialog.ShowDialog() == DialogResult.OK )
            {
                _service.SavePeriods((int)currentAgree.Lic.CustId, currentAgree.Lic.PaidPeriod.ToList());
                paidPeriodBindingSource.CurrencyManager.Refresh();
            }
        }
    }
}
