using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class EtGenreRate
    {
        public int actCode { get; set; }
        public int genreCode { get; set; }
        public decimal? rate { get; set; }

        public ObjAct actCodeNavigation { get; set; }
        public EtGenre genreCodeNavigation { get; set; }
    }
}
