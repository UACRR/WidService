using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelObjGenre : IRelObjGenre
    {
        public int GenreId { get; set; }
        public int ObjId { get; set; }

        public Genre Genre { get; set; }
        public ObjectRight Obj { get; set; }
    }
}

