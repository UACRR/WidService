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
        }

        public void SetCustomerData(Customer cust)
        {
            SetDefaultPages();
            _customer = cust;
            SetUserInfoData();
            gvLicenseAgr.DataSource = new object();
            SetAgrInfoData();
            SetCalculationData();
            SetLicenseAgrGridDataSource();
        }

        private void SetLicenseAgrGridDataSource()
        {
            List<GridLicenseAgrView> source = new List<GridLicenseAgrView>();
            foreach (var item in _customer.Client.LicenseAgreement)
            {
                var licenseParam = item?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == item.LicVersion);
                source.Add(new GridLicenseAgrView
                {
                    Id = 1,
                    License = "",
                    Series = "",
                    AgrNumber = item?.Agr?.AgrNumber,
                    DateBegin = licenseParam?.DateBegin?.ToShortDateString(),
                    DateEnd = licenseParam?.DateEnd?.ToShortDateString(),
                    Amount = "",
                    State = _dictionaties?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == licenseParam?.LicStatus)?.Name,
                    PeriodPayment = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == licenseParam?.PeriodCode)?.Name,
                    DateLastPayment = ""
                });
            }
            
            
            gvLicenseAgr.DataSource = source;
        }

        /// <summary>
        /// Інформація користувача
        /// </summary>
        /// <param name="custId"></param>
        private void SetUserInfoData()
        {
            var userInfo = _customer.AnketaCompany.SingleOrDefault();
            var contactPerson = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3);
            var manager = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 1);


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
        private void SetAgrInfoData()
        {
            var license = _customer.Client.LicenseAgreement.FirstOrDefault(rec => rec.LicStatus < 4);
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
    }

    internal class GridLicenseAgrView
    {
        internal int Id { get; set; }
        internal string License { get; set; }
        internal string Series { get; set; }
        internal string AgrNumber { get; set; }
        internal string DateBegin { get; set; }
        internal string DateEnd { get; set; }
        internal string Amount { get; set; }
        internal string State { get; set; }
        internal string PeriodPayment { get; set; }
        internal string DateLastPayment { get; set; }
    }
}
