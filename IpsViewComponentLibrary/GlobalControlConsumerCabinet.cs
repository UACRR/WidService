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

namespace IpsViewComponentLibrary
{
    /// <inheritdoc />
    /// 1. Передати  AnketaDictionaties,
    /// 2. Передати джерело даних в грід
    /// 3. Підписатись на подію (викликати метод, що повертає Customer)
    public partial class GlobalControlConsumerCabinet : UserControl
    {

        public delegate Customer UpdateData(int id);
        public event UpdateData OnGridRowSelectedChaged;

        public GlobalControlConsumerCabinet()
        {
            InitializeComponent();
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
    }
}
