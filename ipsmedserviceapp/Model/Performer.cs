using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Performer
    {
        public Performer()
        {
            RelObjPerformer = new HashSet<RelObjPerformer>();
        }

        public int perId { get; set; }
        public string perName { get; set; }

        public ICollection<RelObjPerformer> RelObjPerformer { get; set; }
    }
}
