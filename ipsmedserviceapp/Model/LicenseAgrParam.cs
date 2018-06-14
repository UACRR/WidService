using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicenseAgrParam
    {
        public int LicId { get; set; }
        public int LicVersion { get; set; }
        public string LicNum { get; set; }
        public DateTime? LicDate { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? RateAmount { get; set; }
        public bool? IsAutoprolog { get; set; }
        public decimal? AddRate { get; set; }
        public decimal? IndxInfl { get; set; }
        public int? PeriodCode { get; set; }
        public int? DayForPay { get; set; }
        public int? IsCurrent { get; set; }
        public int? LicStatus { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public int? AnkVersion { get; set; }

        public LicenseAgreement Lic { get; set; }
        public AgreementStatus LicStatusNavigation { get; set; }
        public Period PeriodCodeNavigation { get; set; }
    }
}
