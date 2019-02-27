using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PaymentKind
    {
        public PaymentKind()
        {
            PaymentCase = new HashSet<PaymentCase>();
            PaymentKindTr = new HashSet<PaymentKindTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PaymentCase> PaymentCase { get; set; }
        public virtual ICollection<PaymentKindTr> PaymentKindTr { get; set; }
    }
}
