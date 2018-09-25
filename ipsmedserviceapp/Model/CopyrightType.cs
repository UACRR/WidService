using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CopyrightType
    {
        public CopyrightType()
        {
            CopyrightTypeTr = new HashSet<CopyrightTypeTr>();
            CreativeRoleType = new HashSet<CreativeRoleType>();
            myCopyRightType = new HashSet<myCopyRightType>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<CopyrightTypeTr> CopyrightTypeTr { get; set; }
        public ICollection<CreativeRoleType> CreativeRoleType { get; set; }
        public ICollection<myCopyRightType> myCopyRightType { get; set; }
    }
}
