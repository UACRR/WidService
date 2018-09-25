using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class EtGenreRole : IEtGenreRole
    {
        public int genreCode { get; set; }
        public int roleCode { get; set; }
        public int actCode { get; set; }
        public decimal? rate { get; set; }

        public ObjAct actCodeNavigation { get; set; }
        public EtGenre genreCodeNavigation { get; set; }
        public EtRole roleCodeNavigation { get; set; }
    }
}

