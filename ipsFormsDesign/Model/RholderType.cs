using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RholderType : IRholderType
    {
        public RholderType()
        {
            RholderTypeTr = new ObservableListSource<RholderTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<RholderTypeTr> RholderTypeTr { get; set; }
    }
}

