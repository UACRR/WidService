using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class relEtGenre : IrelEtGenre
    {
        public int genreCode { get; set; }
        public int etGenreCode { get; set; }

        public EtGenre etGenreCodeNavigation { get; set; }
        public GenreType genreCodeNavigation { get; set; }
    }
}

