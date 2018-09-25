using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelGenrePercent
    {
        public int actCode { get; set; }
        public int genreType { get; set; }
        public decimal? rate { get; set; }

        public ObjAct actCodeNavigation { get; set; }
        public GenreType genreTypeNavigation { get; set; }
    }
}
