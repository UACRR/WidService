using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Interfaces
{
    /// <summary>
    /// Активний договір єдиний інтерфейс для малих та великих прав
    /// </summary>
    public interface IAgreementData
    {
        string LicenseName { get; }
        string Series { get; }
        string AgrNumber { get; }
        DateTime AgrDate { get; }
        DateTime DateBegin { get; }
        DateTime DateEnd { get; }
        decimal Amount { get; }
        int State { get; }
        string StateName { get; }
        int PeriodPayment { get; }
        string PeriodPaymentName { get; }
        decimal Arrears { get; }
        LicenseAgreement Lic { get;  }
    }
    public static class ActiveAgreementDataFactory
    {
        public static IAgreementData CreateAgreementData(LicenseAgreement license )
        {
            if (license.LicClass == 1)
                return new AgrementDataBr(license);
            else
                return new AgrementDataSR(license);
        }
    }

    internal class baseAgreement
    {
        protected LicenseAgreement _license;
        protected AgrLicenseType _licType;
        protected decimal _arrears;
        internal baseAgreement(LicenseAgreement license)
        {
            _license = license;
            _licType = IpsGlobal.AnketaDictionaties.agrLicenseType.Single(item => item.CodeI == _license.LicCode);
            _arrears = _license.PaidPeriod.Where(rec => rec.EndDate < DateTime.Today).Sum(rec => rec.Amount - rec.Undistribamount - rec.Distribamount);
            if (_arrears < 0)
                _arrears = 0;
        }

        public decimal Arrears { get => _arrears; }
        public string LicenseName { get => _licType.Name; }
        public string Series { get => _licType.Series; }
        public LicenseAgreement Lic { get => _license; }
    }
    internal class AgrementDataSR : baseAgreement, IAgreementData
    {
        LicenseAgrParam _param;
        Period _period;
        AgreementStatus _status;

        internal AgrementDataSR(LicenseAgreement license) : base(license)
        {
            _param = _license.LicenseAgrParam.Single(rec => rec.LicVersion == _license.LicVersion);
            _status = IpsGlobal.AnketaDictionaties.agreementStatus.Single(item => item.CodeI == _param.LicStatus);
            _period = IpsGlobal.AnketaDictionaties.period.Single(item => item.CodeI == _param.PeriodCode);
        }

        public string AgrNumber { get => _param.LicNum; }
        public DateTime AgrDate { get => _param.LicDate ?? DateTime.Today; }
        public DateTime DateBegin { get => _param.DateBegin ?? DateTime.Today; }
        public DateTime DateEnd { get => _param.DateEnd ?? new DateTime(3000,1,1); }
        public decimal Amount { get => _param.MinAmount ?? 0; }
        public int State { get => _param.LicStatus ?? 0; }
        public string StateName { get => _status.Name; }
        public int PeriodPayment { get => _period.CodeI; }
        public string PeriodPaymentName { get => _period.Name; }

    }

    internal class AgrementDataBr : baseAgreement, IAgreementData
    {
        AgreementAddBr _param;
        Period _period;
        AgreementStatus _status;

        internal AgrementDataBr(LicenseAgreement license) : base(license)
        {
            _param = _license.Agr.AgreementAddBr.SingleOrDefault(rec => rec.Version == _license.Agr.Version);
            _status = IpsGlobal.AnketaDictionaties.agreementStatus.Single(item => item.CodeI == (_param?.AgrStatus??0));
            _period = IpsGlobal.AnketaDictionaties.period.Single(item => item.CodeI == (_param?.PeriodCode??1));
        }

        public string AgrNumber { get => (_param?.AgrNumber ?? "") ; }
        public DateTime AgrDate { get => (_param?.AgrDate ?? DateTime.Today); }
        public DateTime DateBegin { get => (_param?.DateBegin ?? DateTime.Today); }
        public DateTime DateEnd { get => (_param?.DateEnd ?? new DateTime(3000, 1, 1)); }
        public decimal Amount { get => 0; }
        public int State { get => _param?.AgrStatus ?? 0; }
        public string StateName { get => _status.Name; }
        public int PeriodPayment { get => _period.CodeI; }
        public string PeriodPaymentName { get => _period.Name; }
    }



}
