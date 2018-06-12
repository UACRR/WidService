using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MoneyReceived
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

        [JsonIgnore]
        public Client Cust { get; set; }
        [JsonIgnore]
        public MoneyType MoneyTypeNavigation { get; set; }
        [JsonIgnore]
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
    }
}

