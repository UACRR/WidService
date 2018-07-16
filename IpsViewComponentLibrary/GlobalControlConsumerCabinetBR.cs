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

namespace IpsViewComponentLibrary
{
    public partial class GlobalControlConsumerCabinetBR : UserControl
    {
        private int _rowId;

        private readonly TypeRights Rights = TypeRights.BigRights;
        private AnketaDictionaties _anketaDictionaties;
        private Customer _customer;
        private IList<ConsumerBigRightView> _brData;
        private IList<VbrLicense> _agrData;
        private IList<BigRightMasterGenAgr> _genAgrs;

        public delegate void BackToMainGrid(int custId);
        /// <summary>
        /// Виникає при натисканні кнопки [До списку споживачів]
        /// </summary>
        public event BackToMainGrid OnBackToGridNeed;

        public delegate void UpdateData(int id);
        /// <summary>
        /// Виникає при зміні поточного рядка на грід та потребі оновити дані
        /// </summary>
        public event UpdateData OnCustomerUpdateDataNeed;

        public event EventHandler OnAddNewCustomer;

        public delegate void EditCustomer(int id);
        public event EditCustomer OnEditCustomer;

        public delegate bool SaveCustomer(Customer customer);
        public event SaveCustomer OnSaveCustomer;//TODO invoke

        public string FilterString
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public GlobalControlConsumerCabinetBR()
        {
            InitializeComponent();
            ctrlCabinet.OnSaveCustomerNeed += CtrlCabinet_OnSaveCustomerNeed;
            //ctrlCabinet.SetAndUpdateData(_customer);
            ctrlCabinet.SetDictionaries(_anketaDictionaties);
        }

        private void CtrlCabinet_OnSaveCustomerNeed(object sender, EventArgs e)
        {
            OnSaveCustomer?.Invoke(_customer);
        }

        /// <summary>
        /// Встановлення джерела даних для гріда
        /// </summary>
        /// <param name="source">Об'єкт джерела даних</param>
        public void SetGridDataSource(IList<ConsumerBigRightView> source)
        {
            _brData = source;
            gvConsumerList.DataSource = _brData;
        }

        public void SetDataAnketaDictionaties(AnketaDictionaties aDictionaties)
        {
            _anketaDictionaties = aDictionaties;
        }

        public void SetDataCustomer(Customer customer)
        {
            _customer = customer;
        }

        public void SetDataAgreementView(IList<object> agrData)
        {
            _agrData = new List<VbrLicense>();
            foreach (var temp in agrData)
                _agrData.Add(temp as VbrLicense);
            
        }

        public void SetAgrMasterList(IList<object> genAgrs)
        {
            _genAgrs = new List<BigRightMasterGenAgr>();
            foreach (var temp in genAgrs)
                _genAgrs.Add(temp as BigRightMasterGenAgr);
        }

        public void SetSelectCustomer(int custId)
        {
            if (gvConsumerList.Rows.Count != 0)
                gvConsumerList.CurrentRow = gvConsumerList.Rows.SingleOrDefault(rec => (int)rec.Cells["CustId"].Value == custId);
        }

        private void gvConsumerList_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if(gvConsumerList.Rows.Count == 0) return;
            
            _rowId = (int?)e?.CurrentRow?.Cells["CustId"]?.Value ?? -1;

            if(_rowId != -1)
            {
                OnCustomerUpdateDataNeed?.Invoke(_rowId);
                ctrlCabinet.SetAndUpdateData(_customer, e.CurrentRow.DataBoundItem as ConsumerBigRightView, _agrData, _genAgrs);
            }
        }

        #region FILTERING (пошук)

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvConsumerList.MasterTemplate.Refresh();
        }

        private void gvConsumerList_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
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

        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBackToGridNeed?.Invoke(_rowId);
        }

        private void btnNewConsumer_Click(object sender, EventArgs e)
        {
            OnAddNewCustomer?.Invoke(sender, e);
        }

        private void btnEditAgr_Click(object sender, EventArgs e)
        {
            OnEditCustomer?.Invoke(_rowId);
        }
    }
}
