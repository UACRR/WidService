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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestControls
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        private ConsumerService _service;
        private EditPay payForm = null;
        private ConsumerMainView _curItem = null;
        private Task<Customer> getCurrentCustomer = null;
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
            if (employee.Count == 0)
                SetButtonDisable();
        }

        private void SetButtonDisable()
        {
            radButton1.Enabled = false;
            radButton2.Enabled = false;
            radButton3.Enabled = false;
        }

        private void normalizeData(Customer cust)
        {
            var dicType = IpsGlobal.AnketaDictionaties.agrLicenseType.ToDictionary(rec => rec.CodeI);
            var dicStatus = IpsGlobal.AnketaDictionaties.agreementStatus.ToDictionary(rec => rec.CodeI);
            var dicPeriod = IpsGlobal.AnketaDictionaties.period.ToDictionary(rec => rec.CodeI);
            foreach (var item in cust.Client.LicenseAgreement)
            {
                item.LicCodeNavigation = dicType[item.LicType ?? 1];
                foreach (var licParam in item.LicenseAgrParam)
                {
                    licParam.Lic = item;
                    licParam.LicStatusNavigation = dicStatus[licParam.LicStatus ?? 1];
                    licParam.PeriodCodeNavigation = dicPeriod[licParam.PeriodCode ?? 1];
                }
            }
        }

        private void radGridView2_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            _curItem = (ConsumerMainView)radGridView2.CurrentRow.DataBoundItem;
            if (_curItem == null)
                return;

            getCurrentCustomer = Task<Customer>.Run(() =>
            {

                var _consumer = _service.GetData(_curItem.CustId);
                normalizeData(_consumer);
                return _consumer;
            });

            Task.Run(() =>
            {

            var listPays = _service.GetCustomerPays(_curItem.CustId);
            ObservableListSource<ExternalPay> listSource = new ObservableListSource<ExternalPay>(listPays);
            if (InvokeRequired)
            {
                checkBox1.Invoke((MethodInvoker)delegate () { checkBox1.Text = _curItem.Name;
                    bindingSource2.DataSource = listSource; ;
                });
                }
                else
                {
                    checkBox1.Text = _curItem.Name;
                    bindingSource2.DataSource = listSource;
                }
            });

            var consumer = getCurrentCustomer.GetAwaiter().GetResult();
            var list = consumer.Client.LicenseAgreement.ToList() ?? new List<LicenseAgreement>();
            var pays = consumer.Client.MoneyReceived.Where(rec => rec.Amount >= rec.DestribAmount + (rec.DestribPrepay ?? 0));
            if (InvokeRequired)
            {
                bindPayPeriod1.Invoke((MethodInvoker)delegate ()
                {
                    bindPayPeriod1.bindingSource1.DataSource = pays;
                    bindPayPeriod1.bindingSource2.DataSource = list;
                });
            }
            else
            {
                bindPayPeriod1.bindingSource1.DataSource = pays;
                bindPayPeriod1.bindingSource2.DataSource = list;

            }




        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            var item = _curItem;
            ExternalPay addRow = new ExternalPay { OkpoCorr = item.Innokpo, NameCorr = item.Name };
            payForm.bindingSource1.DataSource = addRow;

            if (payForm.ShowDialog() == DialogResult.OK)
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


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            radSplitContainer1.SplitPanels[0].Collapsed = !checkBox1.Checked;
        }

        #region ФІЛЬТРАЦІЯ (пошук)

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {
            radGridView2.MasterTemplate.Refresh();
        }

        private void radGridView2_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(radTextBox1.Text))
            {
                radGridView2.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < radGridView2.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                radGridView2.EndUpdate(false);
                return;
            }
            //фільтр не пустий
            radGridView2.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < radGridView2.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(radTextBox1.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }
                radGridView2.EndUpdate(false);
            }
        }

        #endregion

        private void radButton4_Click(object sender, EventArgs e)
        {
            var row = (ExternalPay)radGridView1.CurrentRow.DataBoundItem;
            row.SDebet = 123456;
            bindingSource2.CurrencyManager.Refresh();
        }
    }
}
