using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelGenreRole : IRelGenreRole
    {
        public int RoleCode { get; set; }
        public int GenreType { get; set; }
        public decimal? Rate { get; set; }
        public int ActCode { get; set; }

        public virtual GenreType GenreTypeNavigation { get; set; }
        public virtual CreativeRoleType RoleCodeNavigation { get; set; }
    }
}

