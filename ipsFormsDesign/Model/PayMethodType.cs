using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PayMethodType : IPayMethodType
    {
        public PayMethodType()
        {
            PayMethodTypeTr = new HashSet<PayMethodTypeTr>();
            PaymentCase = new HashSet<PaymentCase>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<PayMethodTypeTr> PayMethodTypeTr { get; set; }
        public ICollection<PaymentCase> PaymentCase { get; set; }
    }
}

