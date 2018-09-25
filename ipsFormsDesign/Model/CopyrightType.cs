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

        public ObservableListSource<CopyrightTypeTr> CopyrightTypeTr { get; set; }
        public ObservableListSource<CreativeRoleType> CreativeRoleType { get; set; }
        public ObservableListSource<MyCopyRightType> MyCopyRightType { get; set; }
    }
}

