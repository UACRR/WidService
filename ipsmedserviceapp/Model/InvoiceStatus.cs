using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class InvoiceStatus
    {
        public InvoiceStatus()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
