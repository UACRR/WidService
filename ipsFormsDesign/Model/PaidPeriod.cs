using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PaidPeriod : IPaidPeriod
    {
        public PaidPeriod()
        {
            BrRegister = new HashSet<BrRegister>();
            Distribution = new HashSet<Distribution>();
            Document = new HashSet<Document>();
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
            Register = new HashSet<Register>();
        }

        public int PeriodId { get; set; }
        public int CustId { get; set; }
        public int PeriodType { get; set; }
        public int LicId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public decimal Undistribamount { get; set; }
        public decimal Distribamount { get; set; }
        public string PeriodName { get; set; }
        public bool? FagFirst { get; set; }

        public Client Cust { get; set; }
        public LicenseAgreement Lic { get; set; }
        public Period PeriodTypeNavigation { get; set; }
        public PeriodStatus StatusNavigation { get; set; }
        public ICollection<BrRegister> BrRegister { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<Document> Document { get; set; }
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ICollection<Register> Register { get; set; }
    }
}

