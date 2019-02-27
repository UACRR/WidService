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
            RegisterExtra = new HashSet<RegisterExtra>();
            RelEtRole = new HashSet<RelEtRole>();
            RelGenreRole = new HashSet<RelGenreRole>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }
        public int Crtype { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual CopyrightType CrtypeNavigation { get; set; }
        public virtual ICollection<Authors> Authors { get; set; }
        public virtual ICollection<CopyRight> CopyRight { get; set; }
        public virtual ICollection<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
        public virtual ICollection<RegisterAuthors> RegisterAuthors { get; set; }
        public virtual ICollection<RegisterExtra> RegisterExtra { get; set; }
        public virtual ICollection<RelEtRole> RelEtRole { get; set; }
        public virtual ICollection<RelGenreRole> RelGenreRole { get; set; }
    }
}
