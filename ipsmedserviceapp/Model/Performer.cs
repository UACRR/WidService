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

        public int PerId { get; set; }
        public string PerName { get; set; }

        public virtual ICollection<RelObjPerformer> RelObjPerformer { get; set; }
    }
}
