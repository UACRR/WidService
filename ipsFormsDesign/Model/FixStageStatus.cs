using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FixStageStatus : IFixStageStatus
    {
        public FixStageStatus()
        {
            Fixation = new ObservableListSource<Fixation>();
        }

        public int CodeI { get; set; }
        public string StageName { get; set; }
        public string StatusName { get; set; }
        public int? StageCode { get; set; }
        public int? StatusCode { get; set; }

        public ObservableListSource<Fixation> Fixation { get; set; }
    }
}

