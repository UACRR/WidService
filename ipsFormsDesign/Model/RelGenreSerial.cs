using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelGenreSerial : IRelGenreSerial
    {
        public int reqId { get; set; }
        public int genreId { get; set; }

        public PopGenre genre { get; set; }
        public RequestSerial req { get; set; }
    }
}

