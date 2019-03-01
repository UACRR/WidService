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
            MyCopyRightType = new HashSet<MyCopyRightType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CopyrightTypeTr> CopyrightTypeTr { get; set; }
        public virtual ICollection<CreativeRoleType> CreativeRoleType { get; set; }
        public virtual ICollection<MyCopyRightType> MyCopyRightType { get; set; }
    }
}
