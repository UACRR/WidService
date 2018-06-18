using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
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

        #region METHODS

        public void SetData(Customer data)
        {
            _data = data;
        }

        public void SetDataSourceForLicAgrGrid(object obj)
        {
            if (obj == null) return;
            gvLicenseAgr.DataSource = obj;
        }

        private void CreateAct()
        {
            MessageBox.Show("Створення акту");
        }

        private void ViewAct()
        {
            MessageBox.Show("Перегляд акту");
        }

        #endregion

        /*  -  *   *   *   *   *   *   *  =  *   *   *   *   *   *   *  -  */
        /*  -  *   *   *   *   *   *   *  =  *   *   *   *   *   *   *  -  */
        /*  -  *   *   *   *   *   *   *  =  *   *   *   *   *   *   *  -  */

        #region EVENTS

        // * * * [Активні договори]
        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            List<GridPeriodsR> source = new List<GridPeriodsR>();
            Random rnd = new Random();
            var period = _data.Client.LicenseAgreement.Where(rec => rec.LicId == (int)gvLicenseAgr.CurrentRow.Cells["LicenseId"].Value).Select(rec => rec.PaidPeriod).SingleOrDefault();
            if (period == null)
            {
                gvPeriods.DataSource = null;
                return;
            }

            foreach (var paidPeriod in period)
            {
                source.Add(new GridPeriodsR
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

        // * * * [Періоди платежів]
        private void gvPeriods_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            List<GridReportsP> source = new List<GridReportsP>();
            var data = _data.Register;
            if (data != null)
            {
                foreach (var item in data)
                {
                    var reports = new GridReportsP
                    {
                        ReportsName = Path.GetFileName(item.FileName),
                        PeriodName = gvPeriods.CurrentRow.Cells["PeriodName"].Value.ToString(),
                        PathString = item.FileName,
                        ReportId = item.RegId
                    };
                    source.Add(reports);
                }
            }

            gvPeriodReports.DataSource = source;
        }

        // * * * [Звіти періода]
        private void gvPeriodReports_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            _path = string.Empty;
            if (gvPeriods.RowCount == 0) return;
            _path = @e?.CurrentRow?.Cells["Path"]?.Value?.ToString();
        }

        // * * *  * * *  КНОПКИ:
        // * * * НА ГРІД [Періоди платежів]
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

        // * * * [Додати звіт]
        private void btnAddReport_Click(object sender, EventArgs e)
        {

        }

        // * * * [Переглянути звіт]
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (gvPeriodReports.Rows.Count == 0 || _path == string.Empty)
            {
                MessageBox.Show("Звіти за обраний період не знайдено!", "Звіти відсутні!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (!File.Exists(_path))
            {
                MessageBox.Show("Неможливо переглянути обраний звіт! Відсутній файл!", "Файл звіту не знайдено!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ReportExcelViewForm viewForm = new ReportExcelViewForm(@_path);
            viewForm.ShowDialog();
        }

        #endregion

    }

    public class GridPeriodsR
    {
        public int PeriodId { get; set; }
        public string PeriodName { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public decimal Distribamount { get; set; }
        public int ReportCounts { get; set; }
        public string IsActFormed { get; set; }
    }

    public class GridReportsP
    {
        public int ReportId { get; set; }
        public string PeriodName { get; set; }
        public string ReportsName { get; set; }
        public string PathString { get; set; }
    }
}
