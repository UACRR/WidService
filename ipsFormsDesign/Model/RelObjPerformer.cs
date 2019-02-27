using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelObjPerformer : IRelObjPerformer
    {
        public int ObjId { get; set; }
        public int PerId { get; set; }

        public virtual ObjectRight Obj { get; set; }
        public virtual Performer Per { get; set; }
    }
}

