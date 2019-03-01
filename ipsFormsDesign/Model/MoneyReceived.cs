using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MoneyReceived : IMoneyReceived
    {
        public MoneyReceived()
        {
            MoneyPeriodLink = new ObservableListSource<MoneyPeriodLink>();
            MoneyPrepayLink = new ObservableListSource<MoneyPrepayLink>();
        }

        public int PaidId { get; set; }
        public int CustId { get; set; }
        public int MoneyType { get; set; }
        public DateTime DateInvoice { get; set; }
        public string NumberInvoice { get; set; }
        public string GoalInvoice { get; set; }
        public decimal Amount { get; set; }
        public decimal DestribAmount { get; set; }
        public decimal? DestribPrepay { get; set; }

        public virtual Client Cust { get; set; }
        public virtual MoneyType MoneyTypeNavigation { get; set; }
        public virtual ObservableListSource<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public virtual ObservableListSource<MoneyPrepayLink> MoneyPrepayLink { get; set; }
    }
}

