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

        public virtual ObjAct ActCodeNavigation { get; set; }
        public virtual EtGenre GenreCodeNavigation { get; set; }
        public virtual EtRole RoleCodeNavigation { get; set; }
    }
}

