using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PaymentCase : IPaymentCase
    {
        public int ReqId { get; set; }
        public int? PayKind { get; set; }
        public int? PayMethod { get; set; }
        public int? PtId { get; set; }
        public DateTime? DateForPay { get; set; }
        public DateTime? DateInvoce { get; set; }
        public DateTime? DatePay { get; set; }
        public int? PayStatus { get; set; }
        public DateTime? DatePayFact { get; set; }
        public string OtherCase { get; set; }

        public PaymentKind PayKindNavigation { get; set; }
        public PayMethodType PayMethodNavigation { get; set; }
        public Request Req { get; set; }
    }
}

