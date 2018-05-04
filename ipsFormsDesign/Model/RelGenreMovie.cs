using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelGenreMovie
    {
        public int ReqId { get; set; }
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        public RequestMovie Req { get; set; }
    }
}
