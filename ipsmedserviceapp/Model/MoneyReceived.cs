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
            MoneyPrepayLink = new HashSet<MoneyPrepayLink>();
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

        [JsonIgnore]
        public Client cust { get; set; }
        [JsonIgnore]
        public MoneyType moneyTypeNavigation { get; set; }
        [JsonIgnore]
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        [JsonIgnore]
        public ICollection<MoneyPrepayLink> MoneyPrepayLink { get; set; }
    }
}

