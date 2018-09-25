using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelGenreSerial
    {
        public int reqId { get; set; }
        public int genreId { get; set; }

        public PopGenre genre { get; set; }
        public RequestSerial req { get; set; }
    }
}
