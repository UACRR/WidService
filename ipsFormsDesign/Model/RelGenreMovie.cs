using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelGenreMovie : IRelGenreMovie
    {
        public int ReqId { get; set; }
        public int GenreId { get; set; }

        public PopGenre Genre { get; set; }
        public RequestMovie Req { get; set; }
    }
}

