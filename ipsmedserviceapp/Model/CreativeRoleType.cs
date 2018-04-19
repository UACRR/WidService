using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CreativeRoleType
    {
        public CreativeRoleType()
        {
            CreativeRoleTypeTr = new HashSet<CreativeRoleTypeTr>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }
        public int Crtype { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public CopyrightType CrtypeNavigation { get; set; }
        public ICollection<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
    }
}
