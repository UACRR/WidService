using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class EtGenreRole : IEtGenreRole
    {
        public int GenreCode { get; set; }
        public int RoleCode { get; set; }
        public int ActCode { get; set; }
        public decimal? Rate { get; set; }

        public ObjAct ActCodeNavigation { get; set; }
        public EtGenre GenreCodeNavigation { get; set; }
        public EtRole RoleCodeNavigation { get; set; }
    }
}

