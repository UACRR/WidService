using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PayTurn : IPayTurn
    {
        public int turnId { get; set; }
        public DateTime dateWork { get; set; }
        public string nD { get; set; }
        public DateTime? nDDate { get; set; }
        public int? accIdDebet { get; set; }
        public int? accIdCredit { get; set; }
        public string accDebet { get; set; }
        public string accCredit { get; set; }
        public decimal? amount { get; set; }
        public decimal? amountCur { get; set; }
        public string payNote { get; set; }
        public string r030 { get; set; }
        public DateTime dateOper { get; set; }
        public int? payStatus { get; set; }
        public int? regId { get; set; }
        public int? distId { get; set; }
        public int? custIdRh { get; set; }

        public Account accIdDebetNavigation { get; set; }
        public PaymentStatus payStatusNavigation { get; set; }
    }
}

