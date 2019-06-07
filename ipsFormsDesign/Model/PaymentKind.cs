using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PaymentKind : IPaymentKind
    {
        public PaymentKind()
        {
            PaymentCase = new ObservableListSource<PaymentCase>();
            PaymentKindTr = new ObservableListSource<PaymentKindTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<PaymentCase> PaymentCase { get; set; }
        public virtual ObservableListSource<PaymentKindTr> PaymentKindTr { get; set; }
    }
}

