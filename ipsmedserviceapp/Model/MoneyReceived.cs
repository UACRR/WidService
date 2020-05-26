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

        public int PaidId { get; set; }
        public int CustId { get; set; }
        public int MoneyType { get; set; }
        public DateTime DateInvoice { get; set; }
        public string NumberInvoice { get; set; }
        public string GoalInvoice { get; set; }
        public decimal Amount { get; set; }
        public decimal DestribAmount { get; set; }
        public decimal? DestribPrepay { get; set; }

        [JsonIgnore]
        public virtual Client Cust { get; set; }
        [JsonIgnore]
        public virtual MoneyType MoneyTypeNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        [JsonIgnore]
        public virtual ICollection<MoneyPrepayLink> MoneyPrepayLink { get; set; }
    }
}



