using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelGenreRole : IRelGenreRole
    {
        public int RoleCode { get; set; }
        public int GenreCode { get; set; }

        public GenreType GenreCodeNavigation { get; set; }
        public CreativeRoleType RoleCodeNavigation { get; set; }
    }
}

