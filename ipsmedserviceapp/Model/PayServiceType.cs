using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PayServiceType
    {
        public PayServiceType()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? PayMethodType { get; set; }

        public virtual PayMethodType PayMethodTypeNavigation { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
