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
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary
{
    public partial class ReportsControl : UserControl
    {
        ExcelEngine _excel = new ExcelEngine();

        public event EventHandler<RegisterRatedList> SaveRegisterRatedListExecuted;
        public event EventHandler<Register> DeleteRegisterExecuted;
        public Func<int, List<RegisterItem>> GetRegisterItems;

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

        private void normalizeData(Customer cust)
        {
            var dicType = IpsGlobal.AnketaDictionaties.agrLicenseType.ToDictionary(rec => rec.CodeI);
            var dicStatus = IpsGlobal.AnketaDictionaties.agreementStatus.ToDictionary(rec => rec.CodeI);
            var dicPeriod = IpsGlobal.AnketaDictionaties.period.ToDictionary(rec => rec.CodeI);
            var dicPeriodStatus = IpsGlobal.AnketaDictionaties.periodStatus.ToDictionary(rec => rec.CodeI);

            foreach (var item in cust.Client.LicenseAgreement)
            {
                item.LicCodeNavigation = dicType[item.LicType ?? 1];

                foreach (var licParam in item.LicenseAgrParam)
                {
                    licParam.Lic = item;
                    licParam.LicStatusNavigation = dicStatus[licParam.LicStatus ?? 1];
                    licParam.PeriodCodeNavigation = dicPeriod[licParam.PeriodCode ?? 1];
                }
                foreach (var period in item.PaidPeriod)
                {
                    period.StatusNavigation = dicPeriodStatus[period.Status];
                    foreach (var link in period.MoneyPeriodLink)
                        link.Period = period;
                    foreach (var regList in period.RegisterRatedList)
                    {
                        regList.Period = period;
                        foreach (var reg in regList.Register)
                            reg.RegisterRatedList = regList;
                    }
                }
            }
        }

        private void SetupBindings()
        {
            if (_customer == null)
            {
                return;
            }
            normalizeData(_customer);
            var listAgreement = _customer.Client.LicenseAgreement.Where(rec => rec.LicStatus == 2).Select(rec => rec.LicenseAgrParam.Single(item => item.LicVersion == rec.LicVersion));
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

            var lic = gvLicenseAgr.CurrentRow.DataBoundItem as LicenseAgrParam;
            bindingPaidPeriod.DataSource = lic?.Lic?.PaidPeriod?.OrderBy(rec => rec.BeginDate);
        }

        // * * * [Періоди платежів]
        private void gvPeriods_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvPeriods.CurrentRow == null)
                return;

            var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;
            var reports = new List<Register>();
            if (period?.RegisterRatedList.Count() > 0)
                foreach (var item in period.RegisterRatedList.OrderBy(rec => rec.RmId))
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

        private void EnableButtons( bool enabled )
        {
            btnAddReport.Enabled = enabled;
            btnViewReport.Enabled = enabled;
            btnDeleteReport.Enabled = enabled;
        }
        // * * * [Додати звіт]
        private void btnAddReport_Click(object sender, EventArgs e)
        {
            if (gvPeriods.CurrentRow == null)
                return;
            var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;
            if (period == null)
                return;

            OpenFileDialog dialog = new OpenFileDialog { AddExtension = true, DefaultExt = "xlsx", Filter = "Excel Files(*.xlsx;*xls)|*.xls;*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                radWaitingBar1.StartWaiting();
                EnableButtons(false);

                var tsk = Task.Run(() =>
                {
                    var list = _excel.GetReportItems(dialog.FileName);
                    if (period.RegisterRatedList.Count() == 0)
                    {
                        period.RegisterRatedList.Add(new RegisterRatedList { PeriodId = period.PeriodId, Status = 0/*Новий*/});
                    }

                    var RatedList = period.RegisterRatedList.First();
                    // Створення Звіту
                    Register addRegister = new Register { RgStatus = 1, FileName = Path.GetFileName(dialog.FileName) };
                    foreach (var item in list)
                        addRegister.RegisterItem.Add(item);

                    RatedList.Register.Add(addRegister);

                    SaveRegisterRatedListExecuted(this, RatedList);
                    BeginInvoke((Action)(() => {
                        radWaitingBar1.StopWaiting();
                        EnableButtons(true);
                    }));
                });


            }

        }

        // * * * [Переглянути звіт]
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (GetRegisterItems == null || gvPeriodReports.CurrentRow == null)
                return;
            var register = gvPeriodReports.CurrentRow.DataBoundItem as Register;
            if (register == null)
                return;

            var list = GetRegisterItems(register.RegId);

            register.RegisterItem.Clear();
            list.ForEach(item => register.RegisterItem.Add(item));

            ReportExcelViewForm viewForm = new ReportExcelViewForm(register);
            viewForm.ShowDialog();
        }

        #endregion

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (GetRegisterItems == null || gvPeriodReports.CurrentRow == null)
                return;
            var register = gvPeriodReports.CurrentRow.DataBoundItem as Register;
            if (register == null)
                return;
            if (MessageBox.Show($"Видалити звіт {register.FileName}", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteRegisterExecuted(this, register);
                var period = gvPeriods.CurrentRow.DataBoundItem as PaidPeriod;
                foreach( var item in period.RegisterRatedList )
                {
                    if( item.Register.Contains( register ))
                    {
                        item.Register.Remove(register);
                        break;
                    }


                }
                bindingReports.Remove(register);
                gvPeriodReports.MasterTemplate.Refresh();
            }
        }
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
