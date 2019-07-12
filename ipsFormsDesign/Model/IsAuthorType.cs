using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class IsAuthorType : IIsAuthorType
    {
        public IsAuthorType()
        {
            CreativeRoleType = new ObservableListSource<CreativeRoleType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<CreativeRoleType> CreativeRoleType { get; set; }
    }
}

