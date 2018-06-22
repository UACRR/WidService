using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class UsesType : IUsesType
    {
        public UsesType()
        {
            UsesKind = new ObservableListSource<UsesKind>();
            UsesTypeTr = new ObservableListSource<UsesTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<UsesKind> UsesKind { get; set; }
        public ObservableListSource<UsesTypeTr> UsesTypeTr { get; set; }
    }
}

