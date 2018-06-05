using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelGenreRole
    {
        public int RoleCode { get; set; }
        public int GenreCode { get; set; }

        public GenreType GenreCodeNavigation { get; set; }
        public CreativeRoleType RoleCodeNavigation { get; set; }
    }
}
