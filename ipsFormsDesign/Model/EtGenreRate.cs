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

        public virtual ObjAct ActCodeNavigation { get; set; }
        public virtual EtGenre GenreCodeNavigation { get; set; }
    }
}

