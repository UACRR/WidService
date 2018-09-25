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

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<PaymentCase> PaymentCase { get; set; }
        public ObservableListSource<PaymentKindTr> PaymentKindTr { get; set; }
    }
}

