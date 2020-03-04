using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PayMethodType
    {
        public PayMethodType()
        {
            PayMethodTypeTr = new HashSet<PayMethodTypeTr>();
            PayServiceType = new HashSet<PayServiceType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PayMethodTypeTr> PayMethodTypeTr { get; set; }
        public virtual ICollection<PayServiceType> PayServiceType { get; set; }
    }
}
