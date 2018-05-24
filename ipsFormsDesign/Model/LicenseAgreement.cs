using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseAgreement : ILicenseAgreement
    {
        public LicenseAgreement()
        {
            BrRegItem = new HashSet<BrRegItem>();
            InverseParentLic = new HashSet<LicenseAgreement>();
            LicPlace = new HashSet<LicPlace>();
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
            PaidPeriod = new HashSet<PaidPeriod>();
        }

        public int LicId { get; set; }
        public int LicCode { get; set; }
        public int? LicType { get; set; }
        public int? CustId { get; set; }
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
        public int? ParentLicId { get; set; }
        public int? LicStatus { get; set; }
        public int? DayForPay { get; set; }
        public int LicClass { get; set; }
        public int AgrId { get; set; }
        public int? LicSize { get; set; }

        public AgreementMaster Agr { get; set; }
        public Client Cust { get; set; }
        public AgrLicenseType LicCodeNavigation { get; set; }
        public AgreementStatus LicStatusNavigation { get; set; }
        public LicenseType LicTypeNavigation { get; set; }
        public LicenseAgreement ParentLic { get; set; }
        public Period PeriodCodeNavigation { get; set; }
        public LicenseBigR LicenseBigR { get; set; }
        public ICollection<BrRegItem> BrRegItem { get; set; }
        public ICollection<LicenseAgreement> InverseParentLic { get; set; }
        public ICollection<LicPlace> LicPlace { get; set; }
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
    }
}

