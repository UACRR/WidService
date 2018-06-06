using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CreativeRoleType : ICreativeRoleType
    {
        public CreativeRoleType()
        {
            Authors = new HashSet<Authors>();
            CopyRight = new HashSet<CopyRight>();
            CreativeRoleTypeTr = new HashSet<CreativeRoleTypeTr>();
            LicAuthor = new HashSet<LicAuthor>();
            RelEtRole = new HashSet<RelEtRole>();
            RelGenreRole = new HashSet<RelGenreRole>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }
        public int Crtype { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public CopyrightType CrtypeNavigation { get; set; }
        public ICollection<Authors> Authors { get; set; }
        public ICollection<CopyRight> CopyRight { get; set; }
        public ICollection<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
        public ICollection<LicAuthor> LicAuthor { get; set; }
        public ICollection<RelEtRole> RelEtRole { get; set; }
        public ICollection<RelGenreRole> RelGenreRole { get; set; }
    }
}

