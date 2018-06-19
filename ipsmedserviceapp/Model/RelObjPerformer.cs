using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelObjPerformer
    {
        public int ObjId { get; set; }
        public int PerId { get; set; }

        public ObjectRight Obj { get; set; }
        public Performer Per { get; set; }
    }
}
