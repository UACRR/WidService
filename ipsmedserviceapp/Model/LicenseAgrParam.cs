using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicenseAgrParam
    {
        public LicenseAgrParam()
        {
            License = new HashSet<License>();
        }

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
        public int? LicStatus { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public int? AnkVersion { get; set; }
        public string Comment { get; set; }
        public int? CntMonth { get; set; }

        public virtual LicenseAgreement Lic { get; set; }
        public virtual AgreementStatus LicStatusNavigation { get; set; }
        public virtual Period PeriodCodeNavigation { get; set; }
        public virtual LicenseBigR LicenseBigR { get; set; }
        public virtual ICollection<License> License { get; set; }
    }
}
