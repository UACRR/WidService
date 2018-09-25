using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelObjPerformer : IRelObjPerformer
    {
        public int objId { get; set; }
        public int perId { get; set; }

        public ObjectRight obj { get; set; }
        public Performer per { get; set; }
    }
}

