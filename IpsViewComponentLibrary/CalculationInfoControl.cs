using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class CalculationInfoControl : UserControl
    {
        private object _data;
        public CalculationInfoControl()
        {
            InitializeComponent();
        }

        public void SetData(object o)
        {
            if (o != null)
                _data = o;
        }

        private void SetDataSource(object obj)
        {
            if (obj != null)
                gvUserMoneys.DataSource = obj;
        }

        private void gvUserMoneys_SelectionChanged(object sender, EventArgs e)
        {
            if(gvUserMoneys.Rows.Count == 0) return;
            //int id = gvUserMoneys.CurrentRow.Cells[0].Value;
            SetDataSourceLicenseAgr(new object());
        }

        private void gvLicenseAgr_SelectionChanged(object sender, EventArgs e)
        {
            if (gvLicenseAgr.Rows.Count == 0) return;
            SetDataSourcePeriodsPayment();
        }

        private void gvPeriodsPayment_SelectionChanged(object sender, EventArgs e)
        {
            if (gvPeriodsPayment.Rows.Count == 0) return;
            SetDataSourcePayments();
        }

        // Джерело для [ліцензійних договорів]
        private void SetDataSourceLicenseAgr(object obj, int id = default(int))
        {
            if (obj != null)
                gvLicenseAgr.DataSource = obj;
        }
        // Джерело для [періодів платежів]
        private void SetDataSourcePeriodsPayment()
        {

        }
        // Джерело для [платежів обраного періоду]
        private void SetDataSourcePayments()
        {

        }
    }
}
