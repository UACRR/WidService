using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PayMethodType : IPayMethodType
    {
        public PayMethodType()
        {
            PayMethodTypeTr = new ObservableListSource<PayMethodTypeTr>();
            PaymentCase = new ObservableListSource<PaymentCase>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<PayMethodTypeTr> PayMethodTypeTr { get; set; }
        public ObservableListSource<PaymentCase> PaymentCase { get; set; }
    }
}

