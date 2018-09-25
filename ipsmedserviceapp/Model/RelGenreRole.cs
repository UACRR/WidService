using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelGenreRole
    {
        public int RoleCode { get; set; }
        public int GenreType { get; set; }
        public decimal? Rate { get; set; }
        public int ActCode { get; set; }

        public GenreType GenreTypeNavigation { get; set; }
        public CreativeRoleType RoleCodeNavigation { get; set; }
    }
}
