using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class EtGenreRate
    {
        public int ActCode { get; set; }
        public int GenreCode { get; set; }
        public decimal? Rate { get; set; }

        public virtual ObjAct ActCodeNavigation { get; set; }
        public virtual EtGenre GenreCodeNavigation { get; set; }
    }
}
