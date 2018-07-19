using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestControls
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        private ConsumerService _service;
        private EditPay payForm = null;
        private ConsumerMainView _curItem = null;
        private bool isInit = false;
        public MainForm()
        {
            _service = new ConsumerService();
            IpsGlobal.SetAnketaDictionaties(_service.GetDictionary());

            InitializeComponent();

            payForm = new EditPay();

            var employee = _service.GetMainView();
            bindingSource1.DataSource = employee;
            if (radGridView1.RowCount > 0)
            {
                radGridView1.Rows[0].IsCurrent = true;
            }
            if( employee.Count == 0 )
                SetButtonDisable();

            isInit = true;
        }

        private void SetButtonDisable()
        {
            radButton1.Enabled=false;
            radButton2.Enabled=false;
            radButton3.Enabled=false;
        }

        private void radGridView2_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            _curItem = (ConsumerMainView)radGridView2.CurrentRow.DataBoundItem;
            if (_curItem == null)
                return;
            var listPays = _service.GetCustomerPays(_curItem.CustId);
            ObservableListSource<ExternalPay> listSource = new ObservableListSource<ExternalPay>(listPays);
            bindingSource2.DataSource = listSource;

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            var item = _curItem;
            ExternalPay addRow = new ExternalPay { OkpoCorr = item.Innokpo, NameCorr = item.Name };
            payForm.bindingSource1.DataSource = addRow;

            if( payForm.ShowDialog() == DialogResult.OK )
            {
                ObservableListSource<ExternalPay> listSource = (ObservableListSource<ExternalPay>)bindingSource2.DataSource;
                ((IListSource)listSource).GetList().Add(addRow);
                radGridView1.Refresh();
                radGridView2.Enabled = false;
            }

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            var list = (ObservableListSource<ExternalPay>)bindingSource2.DataSource;
            _service.SaveNewPayments(_curItem.CustId, list.ToList());
            radGridView2.Enabled = true;
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            var addRow = (ExternalPay)radGridView1.CurrentRow.DataBoundItem;
            payForm.bindingSource1.DataSource = addRow;

            if (payForm.ShowDialog() == DialogResult.OK)
            {
                radGridView2.Enabled = false;
            }
        }
        
        private void radCollapsiblePanel1_Expanded(object sender, EventArgs e)
        {
            radSplitContainer1.SplitPanels[0].SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Absolute;
            radSplitContainer1.SplitPanels[0].SizeInfo.AbsoluteSize = radCollapsiblePanel1.Size;
        }

        private void radCollapsiblePanel1_Collapsed(object sender, EventArgs e)
        {
            radSplitContainer1.SplitPanels[0].SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Absolute;
            radSplitContainer1.SplitPanels[0].SizeInfo.AbsoluteSize = radCollapsiblePanel1.CollapsiblePanelElement.HeaderElement.Size;
        }

        private void splitPanel1_ClientSizeChanged(object sender, EventArgs e)
        {
            radCollapsiblePanel1.Size = radSplitContainer1.SplitPanels[0].Size + new Size(-2,-2);
        }
    }
}
