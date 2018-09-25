using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PayMethodType
    {
        public PayMethodType()
        {
            PayMethodTypeTr = new HashSet<PayMethodTypeTr>();
            PaymentCase = new HashSet<PaymentCase>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<PayMethodTypeTr> PayMethodTypeTr { get; set; }
        public ICollection<PaymentCase> PaymentCase { get; set; }
    }
}
