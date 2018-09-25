using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelPopGenre : IRelPopGenre
    {
        public int genreId { get; set; }
        public int objId { get; set; }

        public PopGenre genre { get; set; }
        public ObjectRight obj { get; set; }
    }
}

