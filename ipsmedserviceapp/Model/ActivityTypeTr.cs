using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ActivityTypeTr
    {
        public int ActivityCode { get; set; }
        public string Lang { get; set; }
        public string ActivityName { get; set; }

        public ActivityType ActivityCodeNavigation { get; set; }
    }
}
