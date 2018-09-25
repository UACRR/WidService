using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class relEtGenre
    {
        public int genreCode { get; set; }
        public int etGenreCode { get; set; }

        public EtGenre etGenreCodeNavigation { get; set; }
        public GenreType genreCodeNavigation { get; set; }
    }
}
