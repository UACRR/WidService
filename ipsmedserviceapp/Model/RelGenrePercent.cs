using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelGenrePercent
    {
        public int ActCode { get; set; }
        public int GenreType { get; set; }
        public decimal? Rate { get; set; }

        public ObjAct ActCodeNavigation { get; set; }
        public GenreType GenreTypeNavigation { get; set; }
    }
}
