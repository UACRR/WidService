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

        public int AccId { get; set; }
        public int? BalsCode { get; set; }
        public int? CustId { get; set; }
        public int? ObjId { get; set; }
        public string R030 { get; set; }
        public string AccNls { get; set; }
        public DateTime? DateOpen { get; set; }
        public DateTime? DateClose { get; set; }
        public int AccStatus { get; set; }
        public string AccName { get; set; }
        public short? AccDk { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual AccountStatus AccStatusNavigation { get; set; }
        public virtual AccountBals BalsCodeNavigation { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual ObjectRight Obj { get; set; }
        public virtual Currency R030Navigation { get; set; }
        public virtual ICollection<PayTurn> PayTurn { get; set; }
    }
}
