using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Performer : IPerformer
    {
        public Performer()
        {
            RelObjPerformer = new HashSet<RelObjPerformer>();
        }

        public int PerId { get; set; }
        public string PerName { get; set; }

        public ICollection<RelObjPerformer> RelObjPerformer { get; set; }
    }
}

