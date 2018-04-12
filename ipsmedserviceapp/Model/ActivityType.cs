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

        public int ActivityCode { get; set; }
        public string ActivityName { get; set; }

        public ICollection<ActivityTypeTr> ActivityTypeTr { get; set; }
    }
}
