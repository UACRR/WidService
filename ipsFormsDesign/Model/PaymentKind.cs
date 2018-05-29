using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PaymentKind : IPaymentKind
    {
        public PaymentKind()
        {
            PaymentCase = new HashSet<PaymentCase>();
            PaymentKindTr = new HashSet<PaymentKindTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<PaymentCase> PaymentCase { get; set; }
        public ICollection<PaymentKindTr> PaymentKindTr { get; set; }
    }
}

