using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FixStageStatus
    {
        public FixStageStatus()
        {
            Fixation = new HashSet<Fixation>();
        }

        public int CodeI { get; set; }
        public string StageName { get; set; }
        public string StatusName { get; set; }
        public int? StageCode { get; set; }
        public int? StatusCode { get; set; }

        public virtual ICollection<Fixation> Fixation { get; set; }
    }
}
