using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelObjPerformer
    {
        public int ObjId { get; set; }
        public int PerId { get; set; }

        public virtual ObjectRight Obj { get; set; }
        public virtual Performer Per { get; set; }
    }
}
