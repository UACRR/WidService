using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Account
    {
        public Account()
        {
            PayTurn = new HashSet<PayTurn>();
        }

        public int accId { get; set; }
        public int? balsCode { get; set; }
        public int? custId { get; set; }
        public int? objId { get; set; }
        public string r030 { get; set; }
        public string accNls { get; set; }
        public DateTime? dateOpen { get; set; }
        public DateTime? dateClose { get; set; }
        public int accStatus { get; set; }
        public string accName { get; set; }
        public short? accDK { get; set; }
        public DateTime? dateModify { get; set; }

        public AccountStatus accStatusNavigation { get; set; }
        public AccountBals balsCodeNavigation { get; set; }
        public Customer cust { get; set; }
        public ObjectRight obj { get; set; }
        public Currency r030Navigation { get; set; }
        public ICollection<PayTurn> PayTurn { get; set; }
    }
}
