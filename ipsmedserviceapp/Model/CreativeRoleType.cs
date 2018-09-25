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
            relEtRole = new HashSet<relEtRole>();
            relGenreRole = new HashSet<relGenreRole>();
        }

        public int codeI { get; set; }
        public int CategoryCode { get; set; }
        public string name { get; set; }
        public int CRType { get; set; }

        public CopyrightType CRTypeNavigation { get; set; }
        public Category CategoryCodeNavigation { get; set; }
        public CreativeTranslate CreativeTranslate { get; set; }
        public ICollection<Authors> Authors { get; set; }
        public ICollection<CopyRight> CopyRight { get; set; }
        public ICollection<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
        public ICollection<RegisterAuthors> RegisterAuthors { get; set; }
        public ICollection<RegisterExtra> RegisterExtra { get; set; }
        public ICollection<relEtRole> relEtRole { get; set; }
        public ICollection<relGenreRole> relGenreRole { get; set; }
    }
}
