using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CopyrightType : ICopyrightType
    {
        public CopyrightType()
        {
            CopyrightTypeTr = new ObservableListSource<CopyrightTypeTr>();
            CreativeRoleType = new ObservableListSource<CreativeRoleType>();
            MyCopyRightType = new ObservableListSource<MyCopyRightType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<CopyrightTypeTr> CopyrightTypeTr { get; set; }
        public virtual ObservableListSource<CreativeRoleType> CreativeRoleType { get; set; }
        public virtual ObservableListSource<MyCopyRightType> MyCopyRightType { get; set; }
    }
}

