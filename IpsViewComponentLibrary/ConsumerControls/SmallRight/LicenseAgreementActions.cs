using System.Linq;
using System.Windows.Forms;
using IPSComponentLibrary.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Common.Enums;
using IpsViewComponentLibrary.ConsumerForms;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight
{
    public class LicenseAgreementActions
    {
        private static LicenseAgreementActions _licenseAgreementActions;

        private LicenseAgreementActions() { }

        public static LicenseAgreementActions GetInstance()
        {
            if (_licenseAgreementActions == null)
                _licenseAgreementActions = new LicenseAgreementActions();

            return _licenseAgreementActions;
        }

        /// <summary>
        /// Створити новий ліцензійний договір
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public LicenseAgreement CreateAgreement(Customer customer)
        {
            var license = new LicenseAgreement
            {
                CustId = customer.CustId,
                LicVersion = 1,
                LicStatus = 0,
                LicCode = 1,
                LicenseAgrParam = new ObservableListSource<LicenseAgrParam>
                {
                    new LicenseAgrParam
                    {
                        LicVersion = 1,
                        LicStatus = 0,
                        PeriodCode = 1,
                    }
                }
            };

            var licenseParam = license.LicenseAgrParam.SingleOrDefault();

            var agreementForm = new AgreementActionsForm(customer.Client.ClnBusinessPlace, license, licenseParam, AgreementModifyType.CreateNewAgreement);
            if (agreementForm.ShowDialog() == DialogResult.OK)
                return license;

            return null;
        }

        /// <summary>
        /// Вікно перегляду документу договору з можливістю друкувати
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="licenseAgreement"></param>
        /// <param name="version"></param>
        public void PrintAgreement(Customer customer, LicenseAgreement licenseAgreement, int? version = null)
        {
            var print = version.HasValue ? new DocumentViewerForm(customer, licenseAgreement, version.Value) : new DocumentViewerForm(customer, licenseAgreement);
            print.ShowDialog();
        }

        public bool EditLicenseAgreement(Customer customer, LicenseAgreement licenseAgreement, LicenseAgrParam licenseAgrParam, AgreementModifyType agreementModifyType)
        {
            var agreementForm = new AgreementActionsForm(customer.Client.ClnBusinessPlace, licenseAgreement, licenseAgrParam, agreementModifyType);
            if (agreementForm.ShowDialog() == DialogResult.OK)
                return true;

            return false;
        }
    }
}
