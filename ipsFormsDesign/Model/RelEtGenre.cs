using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelEtGenre : IRelEtGenre
    {
        public int GenreCode { get; set; }
        public int EtGenreCode { get; set; }

        public EtGenre EtGenreCodeNavigation { get; set; }
        public GenreType GenreCodeNavigation { get; set; }
    }
}

