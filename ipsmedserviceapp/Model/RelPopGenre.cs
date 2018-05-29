using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelPopGenre
    {
        public int GenreId { get; set; }
        public int ObjId { get; set; }

        public PopGenre Genre { get; set; }
        public ObjectRight Obj { get; set; }
    }
}
