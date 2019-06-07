using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PaymentCase
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

        public virtual PaymentKind PayKindNavigation { get; set; }
        public virtual PayMethodType PayMethodNavigation { get; set; }
        public virtual Request Req { get; set; }
    }
}
