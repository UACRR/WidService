using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Performer : IPerformer
    {
        public Performer()
        {
            RelObjPerformer = new ObservableListSource<RelObjPerformer>();
        }

        public int perId { get; set; }
        public string perName { get; set; }

        public ObservableListSource<RelObjPerformer> RelObjPerformer { get; set; }
    }
}

