using System;
using System.Linq;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model
{
    public class RegisterLicenseAgreementModel : ViewModelBase
    {
        public int CustId { get; set; }
        public int LicId { get; set; }

        private int _licCode;
        public int LicCode
        {
            get => _licCode;
            set
            {
                _licCode = value;
                var licType = IpsGlobal.AnketaDictionaties?.agrLicenseType.SingleOrDefault(rec => rec.CodeI == value);

                LicenseSeries = licType?.Series;
                LicenseTypeName = licType?.Name;
                SchemaTypeId = licType?.SchemaId;
                AlgorithmId = licType?.AlgorithmId;

                Debt = _licenseAgreement.PaidPeriod.Where(rec => rec.EndDate < DateTime.Today).Sum(rec => rec.Amount - rec.Undistribamount - rec.Distribamount);
            }
        }

        public string LicenseSeries { get; set; }
        public string LicenseTypeName { get; set; }
        public int? SchemaTypeId { get; set; }
        public int? AlgorithmId { get; set; }

        public string AgrNumber { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        
        public decimal MinAmount { get; set; }
        public decimal Debt { get; set; }

        private int? _periodPaymentCode;
        public int? PeriodPaymentCode
        {
            get => _periodPaymentCode;
            set
            {
                _periodPaymentCode = value;
                var period = IpsGlobal.AnketaDictionaties?.period.SingleOrDefault(rec => rec.CodeI == value);
                PeriodPaymentName = period?.Name;
            }
        }
        public string PeriodPaymentName { get; set; }
        
        private LicenseAgreement _licenseAgreement;
        public LicenseAgreement LicenseAgreement
        {
            get => _licenseAgreement;
            set
            {
                // LicenseAgreement.PaidPeriod is not null
                // LicenseAgreement.LicenseAgrParam be not null

                _licenseAgreement = value;
                ResetData();
            }
        }

        private void ResetData()
        {
            // ReSharper disable once PossibleInvalidOperationException
            CustId = (int)_licenseAgreement.CustId;
            LicId = _licenseAgreement.LicId;
            LicCode = _licenseAgreement.LicCode;

            var agreementParam = _licenseAgreement.LicenseAgrParam.First(rec => rec.LicVersion == _licenseAgreement.LicVersion);

            AgrNumber = agreementParam.LicNum;
            DateBegin = agreementParam.DateBegin;
            DateEnd = agreementParam.DateEnd;
            MinAmount = agreementParam.MinAmount ?? 0m;
            PeriodPaymentCode = agreementParam.PeriodCode;
        }
    }
}
