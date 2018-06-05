using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class EtGenreRate : IEtGenreRate
    {
        public int ActCode { get; set; }
        public int GenreCode { get; set; }
        public decimal? Rate { get; set; }

        public ObjAct ActCodeNavigation { get; set; }
        public EtGenre GenreCodeNavigation { get; set; }
    }
}

