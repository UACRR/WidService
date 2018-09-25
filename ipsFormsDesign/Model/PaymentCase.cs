using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PaymentCase : IPaymentCase
    {
        public int reqId { get; set; }
        public int? payKind { get; set; }
        public int? payMethod { get; set; }
        public int? ptId { get; set; }
        public DateTime? dateForPay { get; set; }
        public DateTime? dateInvoce { get; set; }
        public DateTime? datePay { get; set; }
        public int? payStatus { get; set; }
        public DateTime? datePayFact { get; set; }
        public string otherCase { get; set; }

        public PaymentKind payKindNavigation { get; set; }
        public PayMethodType payMethodNavigation { get; set; }
        public Request req { get; set; }
    }
}

