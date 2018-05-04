using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelObjGenre
    {
        public int GenreId { get; set; }
        public int ObjId { get; set; }

        public Genre Genre { get; set; }
        public ObjectRight Obj { get; set; }
    }
}
