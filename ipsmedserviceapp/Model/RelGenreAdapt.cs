using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelGenreAdapt
    {
        public int reqId { get; set; }
        public int genreId { get; set; }

        public PopGenre genre { get; set; }
        public RequestAdapt req { get; set; }
    }
}
