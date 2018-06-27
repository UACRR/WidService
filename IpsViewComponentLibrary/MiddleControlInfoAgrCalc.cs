using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlInfoAgrCalc : UserControl
    {
        private Customer _customer;
        private AnketaDictionaties _dictionaties;
        private int _idItem;

        public delegate void CustomerSave(Customer customer);
        public event CustomerSave OnCustomerSave;

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
            SetLicenseAgrMoreGridDataSource();
            reportsControl.SetData(cust);
        }

        /// <summary>
        /// Активні договора грід
        /// </summary>
        private void SetLicenseAgrGridDataSource()
        {
            List<GridLicenseAgrView> source = new List<GridLicenseAgrView>();
            if (_customer?.Client.LicenseAgreement != null)
                foreach (var item in _customer.Client.LicenseAgreement)
                {
                    //
                    var licenseParam = item?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == item.LicVersion);
                    source.Add(new GridLicenseAgrView
                    {
                        Id = item?.AgrId ?? default(int),
                        License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == item?.LicCode)?.Name,
                        Series = string.Empty,
                        AgrNumber = licenseParam?.LicNum ?? string.Empty,
                        DateBegin = licenseParam?.DateBegin?.ToShortDateString() ?? string.Empty,
                        DateEnd = licenseParam?.DateEnd?.ToShortDateString() ?? string.Empty,
                        Amount = licenseParam?.MinAmount ?? default(decimal),
                        State = _dictionaties?.agreementStatus
                                    ?.SingleOrDefault(rec => rec.CodeI == licenseParam?.LicStatus)?.Name ??
                                string.Empty,
                        PeriodPayment =
                            _dictionaties?.period?.SingleOrDefault(p => p.CodeI == licenseParam?.PeriodCode)?.Name ??
                            string.Empty,
                        DateLastPayment = ""
                    });
                }

            gvLicenseAgr.DataSource = source;
            gvLicenseAgr.MasterTemplate.Refresh();
            gvLicenseAgr.Update();
        }

        private void SetLicenseAgrMoreGridDataSource()
        {
            List<GridLicenseAgrView> source = new List<GridLicenseAgrView>();
            if (_customer?.Client.LicenseAgreement != null)
                foreach (var item in _customer.Client.LicenseAgreement)
                {
                    source.AddRange(item.LicenseAgrParam.Where(rec => rec.LicVersion > item.LicVersion)
                        .Select(licAgr => new GridLicenseAgrView
                        {
                            Id = item?.AgrId ?? default(int),
                            License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == item?.LicCode)?.Name,
                            Series = string.Empty,
                            AgrNumber = licAgr?.LicNum ?? string.Empty,
                            DateBegin = licAgr?.DateBegin?.ToShortDateString() ?? string.Empty,
                            DateEnd = licAgr?.DateEnd?.ToShortDateString() ?? string.Empty,
                            State = _dictionaties?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == licAgr?.LicStatus)?.Name ?? string.Empty,
                            PeriodPayment = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == licAgr?.PeriodCode)?.Name ?? string.Empty
                        }));
                }

            gvMoreAgr.DataSource = source;
            gvMoreAgr.MasterTemplate.Refresh();
            gvMoreAgr.Update();
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
            userInfoCtrl.PibContactPerson = contactPerson?.Empl?.FirstName + " " +
                                            contactPerson?.Empl?.LastName + " " +
                                            contactPerson?.Empl?.SurName;
            userInfoCtrl.PhoneContactPerson = contactPerson?.Empl?.PhoneNumber;
            userInfoCtrl.EmailContactPerson = contactPerson?.Empl?.Email;
            userInfoCtrl.OrganisationForm = "";
        }

        /// <summary>
        /// Інформація по договору
        /// </summary>
        private void SetAgrInfoData(int idItem = 0)
        {
            _idItem = idItem;
            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.AgrId == idItem).FirstOrDefault(rec => rec.LicStatus < 4);
            var licenseParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);

            agreementInfoCtrl.NumberAgr = licenseParam?.LicNum;
            agreementInfoCtrl.Agent = "";
            agreementInfoCtrl.DateAgr = licenseParam?.LicDate?.ToString("dd.MM.yyyy");


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

        /// <summary>
        /// Встановлення початкових вкладок
        /// </summary>
        private void SetDefaultPages()
        {
            //pvSecond.SelectedPage = pvSecond.DefaultPage;
            //pvMain.SelectedPage = pvMain.DefaultPage;
        }

        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            bool isInt = Int32.TryParse(e.CurrentRow.Cells["Id"].Value.ToString(), out int result);
            if (!isInt) return;
            SetAgrInfoData(result);
        }

        private void pvMain_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pvMain.SelectedPage == pvReports)
                reportsControl.SetDataSourceForLicAgrGrid(calculationCtrl.DataSourceReturn);
        }


        private void btnEditDoc_Click(object sender, EventArgs e)
        {

            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.AgrId == _idItem).FirstOrDefault(rec => rec.LicStatus < 4);
            if (license == null)
                return;

            var licParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);
            var licVersion = license?.LicenseAgrParam.Max(rec => rec.LicVersion);
            LicenseAgrParam newLicense = null;
            // Кількість доп угод з версією більшою за поточну > 0
            if (license.LicenseAgrParam.Count(rec => rec.LicVersion > license.LicVersion) > 0)
            {
                // -- Взяти наступну версію
                newLicense = license.LicenseAgrParam.Where(rec => rec.LicVersion > license.LicVersion).OrderBy(rec => rec.LicVersion).First();
                // -- Сінхронізувати з поточною, окрім версії
                newLicense.SetFields(licParam, new[] { "LicVersion" });
            }
            // Інакше == 0
            else
            {
                // -- Створити нову
                // -- Збільшити версію на 1
                newLicense = new LicenseAgrParam();

                newLicense.SetFields(licParam);
                newLicense.LicDate = DateTime.Now;
                newLicense.DateBegin = DateTime.Now;
                newLicense.DateEnd = DateTime.Now.AddYears(1);
                newLicense.LicVersion = (licVersion ?? 0) + 1;
            }
            //newLicense.LicId = 0;
            license?.LicenseAgrParam?.Add(newLicense);

            var licenseParam = license.LicenseAgrParam.LastOrDefault();

            RunDialogForLicenseAgrParam(license, licenseParam);
        }

        /// <summary>
        /// Визом метода активації договору
        /// </summary>
        /// <param name="license"></param>
        /// <param name="licenseParam"></param>
        private void RunDialogForLicenseAgrParam(LicenseAgreement license, LicenseAgrParam licenseParam)
        {
            var anketaCompany = _customer.Company.AnketaCompany.SingleOrDefault();
            var licenseName = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license?.LicCode)?.Name;

            if (GetTypeAgrForm())
            {
                //з майданчиками
                ProlongationWithPlaces prolongation = new ProlongationWithPlaces(licenseParam, anketaCompany, _dictionaties, licenseName, license, _customer?.Client?.ClnBusinessPlace, _customer)
                {
                    StartPosition = FormStartPosition.CenterParent
                };

                prolongation.ShowDialog();
            }
            else
            {
                // без майданчиків
                ProlongationWithoutPlaces prolongation = new ProlongationWithoutPlaces(licenseParam, anketaCompany, _dictionaties, licenseName, license, _customer)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                prolongation.OnSaveProlongation += Prolongation_OnSaveProlongation;
                prolongation.ShowDialog();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProlongation_Click(object sender, EventArgs e)
        {

            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.AgrId == _idItem).FirstOrDefault(rec => rec.LicStatus < 4);
            if (license == null)
                return;

            var licParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);
            var licVersion = license?.LicenseAgrParam.Max(rec => rec.LicVersion);
            LicenseAgrParam newLicense = null;
            // Кількість доп угод з версією більшою за поточну > 0
            if (license.LicenseAgrParam.Count(rec => rec.LicStatus < 4 && rec.LicVersion > license.LicVersion) > 0)
            {
                // -- Взяти наступну версію
                newLicense = license.LicenseAgrParam.Where(rec => rec.LicVersion > license.LicVersion).OrderBy(rec => rec.LicVersion).First();
                // -- Сінхронізувати з поточною, окрім версії
                newLicense.SetFields(licParam, new[] { "LicVersion" });
            }
            // Інакше == 0
            else {
                // -- Створити нову
                // -- Збільшити версію на 1
                newLicense = new LicenseAgrParam();

                newLicense.SetFields(licParam);
                newLicense.LicDate = DateTime.Now;
                newLicense.DateBegin = DateTime.Now;
                newLicense.DateEnd = DateTime.Now.AddYears(1);
                newLicense.LicVersion = (licVersion ?? 0) + 1;
            }
            //newLicense.LicId = 0;
            license?.LicenseAgrParam?.Add(newLicense);

            var licenseParam = license?.LicenseAgrParam.LastOrDefault();
            RunDialogForLicenseAgrParam(license, licenseParam);
            //var anketaCompany = _customer?.Company?.AnketaCompany?.SingleOrDefault();
            //var licenseName = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license?.LicCode)?.Name;

            //if (GetTypeAgrForm())
            //{
            //    //з майданчиками
            //    ProlongationWithPlaces prolongation = new ProlongationWithPlaces(licenseParam, anketaCompany, _dictionaties, licenseName, license, _customer?.Client?.ClnBusinessPlace, _customer)
            //    {
            //        StartPosition = FormStartPosition.CenterParent
            //    };

            //    prolongation.ShowDialog();
            //}
            //else
            //{
            //    // без майданчиків
            //    ProlongationWithoutPlaces prolongation = new ProlongationWithoutPlaces(licenseParam, anketaCompany, _dictionaties, licenseName, license, _customer)
            //    {
            //        StartPosition = FormStartPosition.CenterParent
            //    };
            //    prolongation.OnSaveProlongation += Prolongation_OnSaveProlongation;
            //    prolongation.ShowDialog();
            //}
        }

        private void Prolongation_OnSaveProlongation(object sender, EventArgs e)
        {
            OnCustomerSave?.Invoke(_customer);
        }

        // true - з майданчиками, false - без майданчиків
        private bool GetTypeAgrForm()
        {
            if (_customer.Client.ClnBusinessPlace.Count > 0)
                return true;
            return false;
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
