using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class InvoiceStatus : IInvoiceStatus
    {
        public InvoiceStatus()
        {
            Invoice = new ObservableListSource<Invoice>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<Invoice> Invoice { get; set; }
    }
}

