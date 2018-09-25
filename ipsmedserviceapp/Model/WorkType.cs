using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class WorkType
    {
        public WorkType()
        {
            WorkRHworkTypeClNavigation = new HashSet<WorkRH>();
            WorkRHworkTypeRHNavigation = new HashSet<WorkRH>();
            WorkTypeTr = new HashSet<WorkTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<WorkRH> WorkRHworkTypeClNavigation { get; set; }
        public ICollection<WorkRH> WorkRHworkTypeRHNavigation { get; set; }
        public ICollection<WorkTypeTr> WorkTypeTr { get; set; }
    }
}
