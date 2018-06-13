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
    public partial class MiddleControlInfoAgrCalc : UserControl
    {
        private Customer _customer;
        private AnketaDictionaties _dictionaties;

        public MiddleControlInfoAgrCalc()
        {
            InitializeComponent();
            SetDefaultPages();
            
        }

        public void SetDictionary(AnketaDictionaties dict)
        {
            _dictionaties = dict;
            calculationCtrl.SetDictionary(dict);
        }

        public void SetCustomerData(Customer cust)
        {
            SetDefaultPages();
            _customer = cust;
            SetUserInfoData();
            gvLicenseAgr.DataSource = new object();
            //SetAgrInfoData();
            SetCalculationData();
            SetLicenseAgrGridDataSource();
        }

        /// <summary>
        /// Активні договора грід
        /// </summary>
        private void SetLicenseAgrGridDataSource()
        {
            List<GridLicenseAgrView> source = new List<GridLicenseAgrView>();
            foreach (var item in _customer.Client.LicenseAgreement)
            {
                //
                var licenseParam = item?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == item.LicVersion);
                source.Add(new GridLicenseAgrView
                {
                    Id = item?.AgrId ?? default(int),
                    License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == item?.LicCode)?.Name,
                    Series = string.Empty,
                    AgrNumber = item?.Agr?.AgrNumber ?? string.Empty,
                    DateBegin = licenseParam?.DateBegin?.ToShortDateString() ?? string.Empty,
                    DateEnd = licenseParam?.DateEnd?.ToShortDateString() ?? string.Empty,
                    Amount = licenseParam?.MinAmount ?? default(decimal),
                    State = _dictionaties?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == licenseParam?.LicStatus)?.Name ?? string.Empty,
                    PeriodPayment = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == licenseParam?.PeriodCode)?.Name ?? string.Empty,
                    DateLastPayment = ""
                });

            }

            gvLicenseAgr.DataSource = source;
            gvLicenseAgr.MasterTemplate.Refresh();
            gvLicenseAgr.Update();
        }

        /// <summary>
        /// Інформація користувача
        /// </summary>
        /// <param name="custId"></param>
        private void SetUserInfoData()
        {
            var userInfo = _customer?.Company?.AnketaCompany?.SingleOrDefault();
            var contactPerson = _customer?.Company?.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3);
            var manager = _customer?.Company?.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 1);


            userInfoCtrl.Edrpou = userInfo?.Okpo;
            userInfoCtrl.NameInfo = userInfo?.Name;
            userInfoCtrl.PibManager = manager?.Empl?.FirstName + " " +
                                      manager?.Empl?.LastName + " " +
                                      manager?.Empl?.SurName;

            userInfoCtrl.PhoneManager = manager?.Empl?.PhoneNumber;
            userInfoCtrl.WorkPositionManager = "";//уточнити
            userInfoCtrl.PibContactPerson = contactPerson?.Empl?.FirstName + " " +
                                            contactPerson?.Empl?.LastName + " " +
                                            contactPerson?.Empl?.SurName;
            userInfoCtrl.WorkPositionContactPerson = "";
            userInfoCtrl.PhoneContactPerson = contactPerson?.Empl?.PhoneNumber;
            userInfoCtrl.MobilePnoneContactPerson = "";
            userInfoCtrl.FaksContactPerson = "";
            userInfoCtrl.EmailContactPerson = contactPerson?.Empl?.Email;
            userInfoCtrl.OrganisationForm = "";
        }

        /// <summary>
        /// Інформація по договору
        /// </summary>
        private void SetAgrInfoData(int idItem = 0)
        {
            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.AgrId == idItem).FirstOrDefault(rec => rec.LicStatus < 4);

            agreementInfoCtrl.NumberAgr = license?.Agr?.AgrNumber;
            agreementInfoCtrl.Agent = "";
            agreementInfoCtrl.DateAgr = license?.Agr?.AgrDate?.ToString("dd.MM.yyyy");
            var licenseParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);

            agreementInfoCtrl.DateBegin = licenseParam?.DateBegin?.ToShortDateString();
            agreementInfoCtrl.DateEnd = licenseParam?.DateEnd?.ToShortDateString();
            agreementInfoCtrl.IsProlongation = licenseParam?.IsAutoprolog ?? false;
            agreementInfoCtrl.PeriodReportind = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == licenseParam?.PeriodCode)?.Name;
            var pr = (_dictionaties?.periodStatus)?.SingleOrDefault(item => item.CodeI == licenseParam?.PeriodCode)?.Name;
            agreementInfoCtrl.Percent = licenseParam?.RateAmount?.ToString();
            agreementInfoCtrl.MinPayment = licenseParam?.MinAmount.ToString();

            agreementInfoCtrl.State = _dictionaties?.agreementStatus.SingleOrDefault(rec => rec.CodeI == licenseParam?.LicStatus)?.Name;
            agreementInfoCtrl.Implementation = "";//буде
            agreementInfoCtrl.IsPaid = true;//буде
            agreementInfoCtrl.Bank = "";//буде
            agreementInfoCtrl.Amount = "";//буде
            agreementInfoCtrl.DistributedAmount = "";//буде
            agreementInfoCtrl.Notation = "";//буде

            agreementInfoCtrl.IsAttach = new Random().Next(-10, 10) > 0;
        }

        /// <summary>
        /// Інформація по розрахункам
        /// </summary>
        private void SetCalculationData()
        {
            calculationCtrl.SetData(_customer);
        }

        private void SetDefaultPages()
        {
            pvSecond.SelectedPage = pvSecond.DefaultPage;
            pvMain.SelectedPage = pvMain.DefaultPage;
        }

        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            bool isInt = Int32.TryParse(e.CurrentRow.Cells["Id"].Value.ToString(), out int result);
            if (!isInt) return;
            SetAgrInfoData(result);
        }

        private void pvMain_SelectedPageChanged(object sender, EventArgs e)
        {
            if(pvMain.SelectedPage == pvReports)
                reportsControl.SetDataSourceForLicAgrGrid(calculationCtrl.DataSourceReturn);
        }
    }

    public class GridLicenseAgrView
    {
        public int Id { get; set; }
        public string License { get; set; }
        public string Series { get; set; }
        public string AgrNumber { get; set; }
        public string DateBegin { get; set; }
        public string DateEnd { get; set; }
        public decimal Amount { get; set; }
        public string State { get; set; }
        public string PeriodPayment { get; set; }
        public string DateLastPayment { get; set; }
    }
}
