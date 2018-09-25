using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelPopGenre
    {
        public int genreId { get; set; }
        public int objId { get; set; }

        public PopGenre genre { get; set; }
        public ObjectRight obj { get; set; }
    }
}
