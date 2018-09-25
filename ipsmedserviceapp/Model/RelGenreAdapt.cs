using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelGenreAdapt
    {
        public int ReqId { get; set; }
        public int GenreId { get; set; }

        public PopGenre Genre { get; set; }
        public RequestAdapt Req { get; set; }
    }
}
