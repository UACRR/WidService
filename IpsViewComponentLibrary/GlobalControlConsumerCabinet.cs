using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System.Diagnostics;

namespace IpsViewComponentLibrary
{
    /// <inheritdoc cref="" />
    /// 1. Передати  AnketaDictionaties,
    /// 2. Передати джерело даних в грід
    /// 3. Підписатись на подію (викликати метод, що повертає Customer)
    public partial class GlobalControlConsumerCabinet : UserControl, IFilteredControl
    {
        private int _rowId;

        public delegate Customer UpdateData(int id);
        public event UpdateData OnGridRowSelectedChaged;

        public delegate void ButtonBackClick(int custId);
        public event ButtonBackClick OnButtonBackClick;

        public event EventHandler OnAddNewCustomer;

        public delegate void EditCustomer(int id);
        public event EditCustomer OnEditCustomer;

        public delegate bool SaveCustomer(Customer customer);
        public event SaveCustomer OnSaveCustomer;

        public event LisenseStatusChangeEventHandler OnChangeLicenseStatus;
        public string FilterString
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public TypeRights Rights { get; set; }

        public GlobalControlConsumerCabinet()
        {
            // Debug.WriteLine("GlobalControlConsumerCabinet 1 start");
            InitializeComponent();
            gvConsumerList.CurrentRowChanged += GvConsumerList_CurrentRowChanged;
            mсInfoAgrCalc.OnCustomerSave += MсInfoAgrCalc_OnCustomerSave;
        }
        public GlobalControlConsumerCabinet(TypeRights typeRights)
        {
            // Debug.WriteLine("GlobalControlConsumerCabinet 2 start");
            InitializeComponent();
            Rights = typeRights;
            gvConsumerList.CurrentRowChanged += GvConsumerList_CurrentRowChanged;
            mсInfoAgrCalc.OnCustomerSave += MсInfoAgrCalc_OnCustomerSave;
            mсInfoAgrCalc.Rights = Rights;
            mсInfoAgrCalc.OnChangeLicenseStatus += MсInfoAgrCalc_OnChangeLicenseStatus;
        }

        private void GlobalControlConsumerCabinet_Load(object sender, EventArgs e)
        {
            int cntObj = 0;
            setPaintEvent(Controls, ref cntObj);
            Debug.WriteLine($"Setup {cntObj} paint event ******** ");
        }

        private void setPaintEvent(Control.ControlCollection controls, ref int cntObj)
        {
            foreach (Control item in controls)
            {
                setPaintEvent(item.Controls, ref cntObj);
                item.Paint += Item_Paint;
                cntObj++;
            }
        }

        private void  NestedName( Control control, StringBuilder sb )
        {
            if (sb.Length > 0)
                sb.Insert(0, ";");
            sb.Insert(0, control.Name);
            if (control.Parent != null && control.Parent is Control)
                NestedName(control.Parent, sb);
        }
        private void Item_Paint(object sender, PaintEventArgs e)
        {
            Control control = sender as Control;
            if (control == null)
                return;
            StringBuilder sb = new StringBuilder();
            NestedName(control, sb);
            Debug.WriteLine($"{DateTime.Now:hh:mm:ss.ffff};{sb.ToString()}");
        }

        private bool MсInfoAgrCalc_OnChangeLicenseStatus(LicenseAgreement agr, int version, int status, bool changeVer)
        {
            // Debug.WriteLine("MсInfoAgrCalc_OnChangeLicenseStatus start");
            return OnChangeLicenseStatus?.Invoke(agr, version, status, changeVer) ?? false;
        }

        private void MсInfoAgrCalc_OnCustomerSave(Customer customer)
        {
            // Debug.WriteLine("MсInfoAgrCalc_OnCustomerSave start");
            var result = OnSaveCustomer?.Invoke(customer) ?? false;
            if (result)
            {
                MessageBox.Show("Успішно збережено!","Збережено",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не можливо зберегти!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GvConsumerList_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            // Debug.WriteLine("GvConsumerList_CurrentRowChanged start");
            var id = (int?)e?.CurrentRow?.Cells["CustId"]?.Value ?? -1;
            _rowId = id;
        }

        public void SetSelectCustomer(int custId)
        {
            // Debug.WriteLine("SetDictionary start");

            if (gvConsumerList.Rows.Count != 0)
                gvConsumerList.CurrentRow = gvConsumerList.Rows.SingleOrDefault(rec => (int)rec.Cells["CustId"].Value == custId);
        }

        /// <summary>
        /// Встановлення AnketaDictionaties
        /// </summary>
        /// <param name="dict"></param>
        public void SetDictionary(AnketaDictionaties dict)
        {
            // Debug.WriteLine("SetDictionary start");
            mсInfoAgrCalc.SetDictionary(dict);
        }

        /// <summary>
        /// Встановлення джерела даних для гріда
        /// </summary>
        /// <param name="o"></param>
        public void SetGridDataSource(object o)
        {
            // Debug.WriteLine("SetGridDataSource start");
            gvConsumerList.DataSource = o;
        }

        /// <summary>
        /// Подія спрацьовує при зміні обраного рядка в гріду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvConsumerList_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            // Debug.WriteLine("gvConsumerList_CurrentRowChanged start");
            int custId = (int?) e?.CurrentRow?.Cells["CustId"]?.Value ?? -1;
            if (custId != -1)
            {
                btnEditAgr.Enabled = true;
                mсInfoAgrCalc.SetStateWhenChangeAnketaCount(AnketaCount.NotEmpty);
                mсInfoAgrCalc.SetCustomerData(OnGridRowSelectedChaged?.Invoke(custId)); //здійснює оновлення даних
            }
            else
            {
                mсInfoAgrCalc.SetStateWhenChangeAnketaCount(AnketaCount.Empty);
                btnEditAgr.Enabled = false;
            }
        }

        public void SetFilter( object _choice )
        {
            // Debug.WriteLine("SetFilter start");
            // Обробка події зміни фільтра
            ConsumerFilterEnum choice = _choice is ConsumerFilterEnum @enum ? @enum : ConsumerFilterEnum.None;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Debug.WriteLine("btnBack_Click start");

            OnButtonBackClick?.Invoke(_rowId);
        }
        //новий споживач
        private void btnNewConsumer_Click(object sender, EventArgs e)
        {
            // Debug.WriteLine("btnNewConsumer_Click start");
            OnAddNewCustomer?.Invoke(this,EventArgs.Empty);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Debug.WriteLine("txtSearch_TextChanged start");
            gvConsumerList.MasterTemplate.Refresh();
        }

        private void gvConsumerList_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            // Debug.WriteLine("gvConsumerList_CustomFiltering start");
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvConsumerList.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvConsumerList.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }

                gvConsumerList.EndUpdate(false);
                return;
            }

            //фільтр не пустий
            gvConsumerList.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvConsumerList.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearch.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
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

                gvConsumerList.EndUpdate(false);
            }
        }

        private void btnEditAgr_Click(object sender, EventArgs e)
        {
            // Debug.WriteLine("btnEditAgr_Click");
            OnEditCustomer?.Invoke(_rowId);
        }



        private void mсInfoAgrCalc_ClientSizeChanged(object sender, EventArgs e)
        {
            // Debug.WriteLine("mсInfoAgrCalc_ClientSizeChanged");
            foreach (Control item in Controls)
                item.SuspendLayout();

            base.OnClientSizeChanged(e);

            foreach (Control item in Controls)
                item.ResumeLayout();
        }


    }
}
