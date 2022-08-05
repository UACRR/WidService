using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PayTurn : IPayTurn
    {
        public int TurnId { get; set; }
        public DateTime DateWork { get; set; }
        public string ND { get; set; }
        public DateTime? NDdate { get; set; }
        public int? AccIdDebet { get; set; }
        public int? AccIdCredit { get; set; }
        public string AccDebet { get; set; }
        public string AccCredit { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountCur { get; set; }
        public string PayNote { get; set; }
        public string R030 { get; set; }
        public DateTime? DateOper { get; set; }
        public int? PayStatus { get; set; }
        public int? RegId { get; set; }
        public int? DistId { get; set; }
        public int? CustIdRh { get; set; }
        public int? RegIitemId { get; set; }
        public int? PayTurnType { get; set; }
        public short? DocType { get; set; }
        public int? HandId { get; set; }
        public decimal? Rate { get; set; }

        public virtual Account AccIdDebetNavigation { get; set; }
        public virtual PaymentStatus PayStatusNavigation { get; set; }
    }
}

