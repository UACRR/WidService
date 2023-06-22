using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Utilities
{
    public static class LicenseAgreementUtility
    {
        public static LicenseAgrParam CurrentLicenseAgrParam(this LicenseAgreement licenseAgreement)
        {
            return licenseAgreement.LicenseAgrParam.SingleOrDefault(i => i.LicVersion == licenseAgreement.LicVersion);
        }

        public static AgreementAddBr CurrentAgreementAddBr(this LicenseAgreement licenseAgreement)
        {
            return licenseAgreement.Agr.AgreementAddBr.SingleOrDefault(rec => rec.Version == licenseAgreement.Agr.Version);
        }

        public static int GetPeriodCode(this LicenseAgreement licenseAgreement)
        {
            int? periodCode;
            if (licenseAgreement.LicClass == 1)
                periodCode = licenseAgreement.CurrentAgreementAddBr()?.PeriodCode;
            else
                periodCode = licenseAgreement.CurrentLicenseAgrParam()?.PeriodCode;

            return periodCode.Value;
        }
    }
}
