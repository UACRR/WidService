using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MoneyReceived : IMoneyReceived
    {
        public MoneyReceived()
        {
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
        }

        public int PaidId { get; set; }
        public int CustId { get; set; }
        public int MoneyType { get; set; }
        public DateTime DateInvoice { get; set; }
        public string NumberInvoice { get; set; }
        public string GoalInvoice { get; set; }
        public decimal Amount { get; set; }
        public decimal DestribAmount { get; set; }

        public Client Cust { get; set; }
        public MoneyType MoneyTypeNavigation { get; set; }
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
    }
}

