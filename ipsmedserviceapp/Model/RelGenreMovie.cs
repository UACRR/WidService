using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelGenreMovie
    {
        public int ReqId { get; set; }
        public int GenreId { get; set; }

        public virtual PopGenre Genre { get; set; }
        public virtual RequestMovie Req { get; set; }
    }
}
