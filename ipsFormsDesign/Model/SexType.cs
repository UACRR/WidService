using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SexType : ISexType
    {
        public SexType()
        {
            AnketaPerson = new ObservableListSource<AnketaPerson>();
            SexTypeTr = new ObservableListSource<SexTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public virtual ObservableListSource<SexTypeTr> SexTypeTr { get; set; }
    }
}

