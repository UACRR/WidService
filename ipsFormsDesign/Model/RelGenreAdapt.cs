using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelGenreAdapt : IRelGenreAdapt
    {
        public int reqId { get; set; }
        public int genreId { get; set; }

        public PopGenre genre { get; set; }
        public RequestAdapt req { get; set; }
    }
}

