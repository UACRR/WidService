using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PayServiceType : IPayServiceType
    {
        public PayServiceType()
        {
            Invoice = new ObservableListSource<Invoice>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? PayMethodType { get; set; }

        public virtual PayMethodType PayMethodTypeNavigation { get; set; }
        public virtual ObservableListSource<Invoice> Invoice { get; set; }
    }
}

