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

        public int paidId { get; set; }
        public int custId { get; set; }
        public int moneyType { get; set; }
        public DateTime dateInvoice { get; set; }
        public string numberInvoice { get; set; }
        public string goalInvoice { get; set; }
        public decimal amount { get; set; }
        public decimal destribAmount { get; set; }
        public decimal? destribPrepay { get; set; }

        public Client cust { get; set; }
        public MoneyType moneyTypeNavigation { get; set; }
        public ObservableListSource<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ObservableListSource<MoneyPrepayLink> MoneyPrepayLink { get; set; }
    }
}

