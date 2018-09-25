using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelGenreMovie
    {
        public int reqId { get; set; }
        public int genreId { get; set; }

        public PopGenre genre { get; set; }
        public RequestMovie req { get; set; }
    }
}
