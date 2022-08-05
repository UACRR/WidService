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
            PayServiceType = new ObservableListSource<PayServiceType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<PayMethodTypeTr> PayMethodTypeTr { get; set; }
        public virtual ObservableListSource<PayServiceType> PayServiceType { get; set; }
    }
}

