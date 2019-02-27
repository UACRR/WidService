using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelPopGenre
    {
        public int GenreId { get; set; }
        public int ObjId { get; set; }

        public virtual PopGenre Genre { get; set; }
        public virtual ObjectRight Obj { get; set; }
    }
}
