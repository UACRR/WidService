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
            MoneyPeriodLink = new ObservableListSource<MoneyPeriodLink>();
            RegisterRatedList = new ObservableListSource<RegisterRatedList>();
        }

        public int periodId { get; set; }
        public int custId { get; set; }
        public int periodType { get; set; }
        public int licId { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public int status { get; set; }
        public decimal amount { get; set; }
        public decimal undistribamount { get; set; }
        public decimal distribamount { get; set; }
        public string periodName { get; set; }
        public bool? fagFirst { get; set; }
        public DateTime? dateActPrint { get; set; }

        public Client cust { get; set; }
        public LicenseAgreement lic { get; set; }
        public Period periodTypeNavigation { get; set; }
        public PeriodStatus statusNavigation { get; set; }
        public ObservableListSource<BrRegister> BrRegister { get; set; }
        public ObservableListSource<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ObservableListSource<RegisterRatedList> RegisterRatedList { get; set; }
    }
}

