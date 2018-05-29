using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelPopGenre : IRelPopGenre
    {
        public int GenreId { get; set; }
        public int ObjId { get; set; }

        public PopGenre Genre { get; set; }
        public ObjectRight Obj { get; set; }
    }
}

