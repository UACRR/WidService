using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            ActivityTypeTr = new HashSet<ActivityTypeTr>();
            AnketaCompany = new HashSet<AnketaCompany>();
            ReqCustomer = new HashSet<ReqCustomer>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ActivityTypeTr> ActivityTypeTr { get; set; }
        public virtual ICollection<AnketaCompany> AnketaCompany { get; set; }
        public virtual ICollection<ReqCustomer> ReqCustomer { get; set; }
    }
}
