using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelEtGenre
    {
        public int GenreCode { get; set; }
        public int EtGenreCode { get; set; }

        public virtual EtGenre EtGenreCodeNavigation { get; set; }
        public virtual GenreType GenreCodeNavigation { get; set; }
    }
}
