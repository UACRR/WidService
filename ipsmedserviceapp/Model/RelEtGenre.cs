using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelEtGenre
    {
        public int GenreCode { get; set; }
        public int EtGenreCode { get; set; }

        public EtGenre EtGenreCodeNavigation { get; set; }
        public GenreType GenreCodeNavigation { get; set; }
    }
}
