using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            ActivityTypeTr = new HashSet<ActivityTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<ActivityTypeTr> ActivityTypeTr { get; set; }
    }
}
