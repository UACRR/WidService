using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelGenreSerial : IRelGenreSerial
    {
        public int ReqId { get; set; }
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        public RequestSerial Req { get; set; }
    }
}

