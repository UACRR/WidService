using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class IsAuthorType
    {
        public IsAuthorType()
        {
            CreativeRoleType = new HashSet<CreativeRoleType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CreativeRoleType> CreativeRoleType { get; set; }
    }
}
