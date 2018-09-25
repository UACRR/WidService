using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class EtGenreRate : IEtGenreRate
    {
        public int actCode { get; set; }
        public int genreCode { get; set; }
        public decimal? rate { get; set; }

        public ObjAct actCodeNavigation { get; set; }
        public EtGenre genreCodeNavigation { get; set; }
    }
}

