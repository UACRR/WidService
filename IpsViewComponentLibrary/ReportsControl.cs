using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System.Windows.Forms;


namespace IpsViewComponentLibrary
{
    public partial class ReportsControl : UserControl
    {
        private Customer _data;
        private string _path;
        public ReportsControl()
        {
            InitializeComponent();
        }

        public void SetData(Customer data)
        {
            _data = data;
        }


        public void SetDataSourceForLicAgrGrid(object obj)
        {
            if(obj == null) return;
            gvLicenseAgr.DataSource = obj;
        }

        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            List<GridPeriodsReports> source = new List<GridPeriodsReports>();
            Random rnd = new Random();
            var period = _data.Client.LicenseAgreement.Where(rec => rec.LicId == (int)gvLicenseAgr.CurrentRow.Cells["LicenseId"].Value).Select(rec => rec.PaidPeriod).SingleOrDefault();
            if (period == null)
            {
                gvPeriods.DataSource = null;
                return;
            }
            
            foreach (var paidPeriod in period)
            {
                source.Add(new GridPeriodsReports
                {
                    PeriodId = paidPeriod.PeriodId,
                    PeriodName = paidPeriod.PeriodName,
                    Status = paidPeriod.Status,
                    Amount = paidPeriod.Amount,
                    Distribamount = paidPeriod.Distribamount,
                    IsActFormed = rnd.Next(20) > 10 ? "Так" : "Ні",
                    ReportCounts = rnd.Next(5),
                });
            }
            gvPeriods.DataSource = source;
        }

        private void gvPeriods_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            //set datasource gvPeriodReports

        }

        private void btnAddReport_Click(object sender, EventArgs e)
        {

        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (gvPeriodReports.Rows.Count == 0)
            {
                MessageBox.Show("Звіти за обраний період не знайдено!", "Звіти відсутні!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            
            ReportExcelViewForm viewForm = new ReportExcelViewForm(@_path);
            viewForm.ShowDialog();
        }

        private void gvPeriods_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "CreateAct":
                    CreateAct();
                    break;
                case "ViewAct":
                    ViewAct();
                    break;
            }
            
        }

        private void CreateAct()
        {
            MessageBox.Show("Створення акту");
        }

        private void ViewAct()
        {
            MessageBox.Show("Перегляд акту");
        }

        //звіти періода
        private void gvPeriodReports_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            _path = string.Empty;
            if (gvPeriods.RowCount == 0) return;
            _path = @e?.CurrentRow?.Cells["Path"]?.Value?.ToString();
        }
    }

    public class GridPeriodsReports
    {
        public int PeriodId { get; set; }

        public string PeriodName { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public decimal Distribamount { get; set; }
        public int ReportCounts { get; set; }
        public string IsActFormed { get; set; }
    }
}
