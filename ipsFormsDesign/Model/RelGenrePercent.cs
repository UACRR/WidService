using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelGenrePercent : IRelGenrePercent
    {
        public int ActCode { get; set; }
        public int GenreType { get; set; }
        public decimal? Rate { get; set; }

        public virtual ObjAct ActCodeNavigation { get; set; }
        public virtual GenreType GenreTypeNavigation { get; set; }
    }
}

