using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SpecType : ISpecType
    {
        public SpecType()
        {
            ObjectRight = new ObservableListSource<ObjectRight>();
            SpecTypeTr = new ObservableListSource<SpecTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<ObjectRight> ObjectRight { get; set; }
        public virtual ObservableListSource<SpecTypeTr> SpecTypeTr { get; set; }
    }
}

