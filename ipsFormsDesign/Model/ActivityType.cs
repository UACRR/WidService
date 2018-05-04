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

        public ICollection<ActivityTypeTr> ActivityTypeTr { get; set; }
        public ICollection<AnketaCompany> AnketaCompany { get; set; }
        public ICollection<ReqCustomer> ReqCustomer { get; set; }
    }
}
