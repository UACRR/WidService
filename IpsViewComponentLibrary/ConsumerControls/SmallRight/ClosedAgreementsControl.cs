using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPSComponentLibrary.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerControls.SmallRight;
using IpsViewComponentLibrary.ConsumerControls.SmallRight.InternalModel;
using IpsViewComponentLibrary.ConsumerForms;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class ClosedAgreementsControl : UserControl
    {
        private readonly AnketaDictionaties _dictionaties;
        private Customer _customer;
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public ClosedAgreementsControl()
        {
            InitializeComponent();
            if (!IsDesignMode)
                _dictionaties = IpsGlobal.AnketaDictionaties;
        }

        public void SetClosedLicenses(Customer customer)
        {
            _customer = customer;
            GenerateGridDataSource();
        }

        private void GenerateGridDataSource()
        {
            List<GridLicenseAgreementView> source = new List<GridLicenseAgreementView>();
            if (_customer?.Client?.LicenseAgreement != null)
            {
                foreach (var license in _customer.Client.LicenseAgreement.Where(rec => rec.LicClass == 0).ToList())
                {
                    foreach (var licenseAgrParam in license.LicenseAgrParam.Where(rec => rec.LicStatus == 4).ToList())
                    {
                        source.Add(new GridLicenseAgreementView
                        {
                            Id = license.AgrId,
                            LicId = license.LicId,
                            LicenseCode = string.Concat(licenseAgrParam.LicId, "/", licenseAgrParam.LicVersion),
                            LicVersion = licenseAgrParam.LicVersion,
                            License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license.LicCode)?.Name,
                            Series = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license.LicCode)?.Series,
                            MinAmount = licenseAgrParam.MinAmount ?? default(decimal),
                            MinRate = licenseAgrParam.RateAmount ?? default(decimal),
                            AgrNumber = licenseAgrParam.LicNum ?? string.Empty,
                            AgrMasterNumber = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion)?.LicNum,
                            DateBegin = licenseAgrParam.DateBegin?.ToShortDateString() ?? string.Empty,
                            DateEnd = licenseAgrParam.DateEnd?.ToShortDateString() ?? string.Empty,
                            State = _dictionaties?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == licenseAgrParam?.LicStatus)?.Name ?? string.Empty,
                            Status = licenseAgrParam.LicStatus,
                            PeriodPayment = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == licenseAgrParam?.PeriodCode)?.Name ?? string.Empty,
                            IsAutoprolog = licenseAgrParam.IsAutoprolog ?? false,
                        });
                    }
                }
            }

            gvClosedLicenses.DataSource = source;
            gvClosedLicenses.MasterTemplate.Refresh();
            gvClosedLicenses.Update();
        }

        // перегляд договору
        private void gvClosedLicenses_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var row = e.Row.DataBoundItem as GridLicenseAgreementView;
            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == row.LicId);
            var print = new DocumentViewerForm(_customer, license, (int)row.LicVersion);
            print.ShowDialog();
        }
    }
}
