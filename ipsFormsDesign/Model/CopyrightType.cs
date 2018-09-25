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
            myCopyRightType = new ObservableListSource<myCopyRightType>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<CopyrightTypeTr> CopyrightTypeTr { get; set; }
        public ObservableListSource<CreativeRoleType> CreativeRoleType { get; set; }
        public ObservableListSource<myCopyRightType> myCopyRightType { get; set; }
    }
}

