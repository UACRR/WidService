using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelEtGenre : IRelEtGenre
    {
        public int GenreCode { get; set; }
        public int EtGenreCode { get; set; }

        public virtual EtGenre EtGenreCodeNavigation { get; set; }
        public virtual GenreType GenreCodeNavigation { get; set; }
    }
}

