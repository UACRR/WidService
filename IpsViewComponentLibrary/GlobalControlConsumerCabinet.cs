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
    /// <inheritdoc cref="" />
    /// 1. Передати  AnketaDictionaties,
    /// 2. Передати джерело даних в грід
    /// 3. Підписатись на подію (викликати метод, що повертає Customer)
    public partial class GlobalControlConsumerCabinet : UserControl, IFilteredControl
    {

        public delegate Customer UpdateData(int id);
        public event UpdateData OnGridRowSelectedChaged;

        public delegate void ButtonBackClick(int custId);

        public event ButtonBackClick OnButtonBackClick;
        public GlobalControlConsumerCabinet()
        {
            InitializeComponent();
        }

        public void SetSelectCustomer(int custId)
        {
            if (gvConsumerList.Rows.Count != 0)
                gvConsumerList.CurrentRow = gvConsumerList.Rows[gvConsumerList.Rows.Where(rec => (int)rec.Cells["CustId"].Value == custId).Select(rec => rec.Index).SingleOrDefault()];
        }

        /// <summary>
        /// Встановлення AnketaDictionaties
        /// </summary>
        /// <param name="dict"></param>
        public void SetDictionary(AnketaDictionaties dict)
        {
            mсInfoAgrCalc.SetDictionary(dict);
        }

        /// <summary>
        /// Встановлення джерела даних для гріда
        /// </summary>
        /// <param name="o"></param>
        public void SetGridDataSource(object o)
        {
            gvConsumerList.DataSource = o;
        }

        /// <summary>
        /// Подія спрацьовує при зміні обраного рядка в гріду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvConsumerList_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            int custId = (int)e.CurrentRow.Cells["CustId"].Value;
            mсInfoAgrCalc.SetCustomerData(OnGridRowSelectedChaged?.Invoke(custId)); //здійснює оновлення даних
        }

        public void SetFilter( object _choice )
        {
            // Обробка події зміни фільтра
            ConsumerFilterEnum choice = _choice is ConsumerFilterEnum @enum ? @enum : ConsumerFilterEnum.None;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnButtonBackClick?.Invoke((int)gvConsumerList.CurrentRow.Cells["CustId"].Value);
        }
    }
}
