using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementMaster
    {
        public AgreementMaster()
        {
            InverseParentAgr = new HashSet<AgreementMaster>();
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
            PaidPeriod = new HashSet<PaidPeriod>();
        }

        public int AgrId { get; set; }
        public int CustId { get; set; }
        public int? ParentAgrId { get; set; }
        public int? AgrStatus { get; set; }
        public string AgrNumber { get; set; }
        public DateTime? AgrDate { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public int? AgrType { get; set; }

        public AgreementStatus AgrStatusNavigation { get; set; }
        public Customer Cust { get; set; }
        public AgreementMaster ParentAgr { get; set; }
        public AgreementAddPartner AgreementAddPartner { get; set; }
        public AgreementAddRh AgreementAddRh { get; set; }
        public ICollection<AgreementMaster> InverseParentAgr { get; set; }
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
    }
}
