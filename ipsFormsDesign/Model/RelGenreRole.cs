using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class relGenreRole : IrelGenreRole
    {
        public int roleCode { get; set; }
        public int genreType { get; set; }
        public decimal? rate { get; set; }
        public int actCode { get; set; }

        public GenreType genreTypeNavigation { get; set; }
        public CreativeRoleType roleCodeNavigation { get; set; }
    }
}

