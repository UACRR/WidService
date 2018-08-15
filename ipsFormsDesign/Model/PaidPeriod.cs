using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PaidPeriod : IPaidPeriod
    {
        public PaidPeriod()
        {
            BrRegister = new ObservableListSource<BrRegister>();
            Distribution = new ObservableListSource<Distribution>();
            MoneyPeriodLink = new ObservableListSource<MoneyPeriodLink>();
            RegisterRatedList = new ObservableListSource<RegisterRatedList>();
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
        public DateTime? DateActPrint { get; set; }

        public Client Cust { get; set; }
        public LicenseAgreement Lic { get; set; }
        public Period PeriodTypeNavigation { get; set; }
        public PeriodStatus StatusNavigation { get; set; }
        public ObservableListSource<BrRegister> BrRegister { get; set; }
        public ObservableListSource<Distribution> Distribution { get; set; }
        public ObservableListSource<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ObservableListSource<RegisterRatedList> RegisterRatedList { get; set; }
    }
}

