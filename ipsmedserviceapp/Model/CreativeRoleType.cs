using Newtonsoft.Json;
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
        public int? IsAuthorType { get; set; }

        [JsonIgnore]
        public virtual Category CategoryCodeNavigation { get; set; }
        [JsonIgnore]
        public virtual CopyrightType CrtypeNavigation { get; set; }
        [JsonIgnore]
        public virtual IsAuthorType IsAuthorTypeNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Authors> Authors { get; set; }
        [JsonIgnore]
        public virtual ICollection<CopyRight> CopyRight { get; set; }
        [JsonIgnore]
        public virtual ICollection<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
        [JsonIgnore]
        public virtual ICollection<RegisterAuthors> RegisterAuthors { get; set; }
        [JsonIgnore]
        public virtual ICollection<RegisterExtra> RegisterExtra { get; set; }
        [JsonIgnore]
        public virtual ICollection<RelEtRole> RelEtRole { get; set; }
        [JsonIgnore]
        public virtual ICollection<RelGenreRole> RelGenreRole { get; set; }
    }
}

