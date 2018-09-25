using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class relGenreRole
    {
        public int roleCode { get; set; }
        public int genreType { get; set; }
        public decimal? rate { get; set; }
        public int actCode { get; set; }

        public GenreType genreTypeNavigation { get; set; }
        public CreativeRoleType roleCodeNavigation { get; set; }
    }
}
