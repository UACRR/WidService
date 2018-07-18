using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CreativeRoleType
    {
        public CreativeRoleType()
        {
            Authors = new HashSet<Authors>();
            CopyRight = new HashSet<CopyRight>();
            CreativeRoleTypeTr = new HashSet<CreativeRoleTypeTr>();
            RegisterAuthors = new HashSet<RegisterAuthors>();
            RelEtRole = new HashSet<RelEtRole>();
            RelGenreRole = new HashSet<RelGenreRole>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }
        public int Crtype { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public CopyrightType CrtypeNavigation { get; set; }
        public CreativeTranslate CreativeTranslate { get; set; }
        public ICollection<Authors> Authors { get; set; }
        public ICollection<CopyRight> CopyRight { get; set; }
        public ICollection<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
        public ICollection<RegisterAuthors> RegisterAuthors { get; set; }
        public ICollection<RelEtRole> RelEtRole { get; set; }
        public ICollection<RelGenreRole> RelGenreRole { get; set; }
    }
}
