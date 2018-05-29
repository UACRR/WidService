using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Account : IAccount
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

        public AccountStatus AccStatusNavigation { get; set; }
        public AccountBals BalsCodeNavigation { get; set; }
        public Customer Cust { get; set; }
        public ObjectRight Obj { get; set; }
        public Currency R030Navigation { get; set; }
        public ICollection<PayTurn> PayTurn { get; set; }
    }
}

