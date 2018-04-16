using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PayMethodType
    {
        public PayMethodType()
        {
            PayMethodTypeTr = new HashSet<PayMethodTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<PayMethodTypeTr> PayMethodTypeTr { get; set; }
    }
}
