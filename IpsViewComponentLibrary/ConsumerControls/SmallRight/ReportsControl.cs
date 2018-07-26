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
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary
{
    public partial class ReportsControl : UserControl
    {
        ExcelEngine _excel = new ExcelEngine();

        public event EventHandler<RegisterRatedList> SaveRegisterRatedListExecuted;

        public ReportsControl()
        {
            InitializeComponent();
        }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                SetupBindings();
            }
        }

        #region METHODS

        private void SetupBindings()
        {
            if (_customer == null)
            {
                return;
            }

            var listAgreement = _customer.Client.LicenseAgreement.Where(rec => rec.LicStatus == 2);
            bindingLicAgreement.DataSource = listAgreement;
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


        #region EVENTS

        // * * * [Активні договори]
        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvLicenseAgr.CurrentRow == null)
                return;

            var lic = gvLicenseAgr.CurrentRow.DataBoundItem as LicenseAgreement;
            bindingPaidPeriod.DataSource = lic.PaidPeriod;
        }

        // * * * [Періоди платежів]
        private void gvPeriods_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvPeriods.CurrentRow == null)
                return;

            var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;
            var reports = new List<Register>();
            foreach (var item in period.RegisterRatedList)
            {
                reports.AddRange(item.Register);
            }

            bindingReports.DataSource = reports;
        }

        // * * * [Звіти періода]
        private void gvPeriodReports_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
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
            if (gvPeriodReports.CurrentRow == null)
                return;
            var period = gvPeriodReports.CurrentRow.DataBoundItem as PaidPeriod;
            if (period == null)
                return;

            OpenFileDialog dialog = new OpenFileDialog { AddExtension=true, DefaultExt="xlsx", Filter="Excel Files(*.xlsx;*xls)|*.xls;*.xlsx"};
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                var list = _excel.GetReportItems(dialog.FileName);
                if( period.RegisterRatedList.Count() == 0 )
                {
                    period.RegisterRatedList.Add(new RegisterRatedList { PeriodId = period.PeriodId, Status = 0/*Новий*/});
                }

                var RatedList = period.RegisterRatedList.First();
                Register addRegister = new Register { RgStatus=0, FileName = Path.GetFileName(dialog.FileName) };
                foreach (var item in list)
                    addRegister.RegisterItem.Add(item);

                RatedList.Register.Add(addRegister);

                SaveRegisterRatedListExecuted(this,RatedList);
            }

        }

        // * * * [Переглянути звіт]
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            string _path = "";
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
