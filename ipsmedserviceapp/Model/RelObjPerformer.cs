using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelObjPerformer
    {
        public int objId { get; set; }
        public int perId { get; set; }

        public ObjectRight obj { get; set; }
        public Performer per { get; set; }
    }
}
