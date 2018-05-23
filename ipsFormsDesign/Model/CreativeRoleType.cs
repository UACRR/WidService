using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CreativeRoleType : ICreativeRoleType
    {
        public CreativeRoleType()
        {
            CopyRight = new HashSet<CopyRight>();
            CreativeRoleTypeTr = new HashSet<CreativeRoleTypeTr>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }
        public int Crtype { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public CopyrightType CrtypeNavigation { get; set; }
        public ICollection<CopyRight> CopyRight { get; set; }
        public ICollection<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
    }
}

