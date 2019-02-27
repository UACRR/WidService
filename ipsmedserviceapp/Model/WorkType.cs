using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class WorkType
    {
        public WorkType()
        {
            WorkRhWorkTypeClNavigation = new HashSet<WorkRh>();
            WorkRhWorkTypeRhNavigation = new HashSet<WorkRh>();
            WorkTypeTr = new HashSet<WorkTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkRh> WorkRhWorkTypeClNavigation { get; set; }
        public virtual ICollection<WorkRh> WorkRhWorkTypeRhNavigation { get; set; }
        public virtual ICollection<WorkTypeTr> WorkTypeTr { get; set; }
    }
}
