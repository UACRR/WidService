using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DocPreparePay : IDocPreparePay
    {
        public int DocPayId { get; set; }
        public DateTime DateWork { get; set; }
        public int? RegId { get; set; }
        public int? DistId { get; set; }
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
        public DateTime DateOper { get; set; }
        public int? PayStatus { get; set; }
        public int? Paidid { get; set; }
        public byte? FlCourt { get; set; }

        public PaymentStatus PayStatusNavigation { get; set; }
    }
}

