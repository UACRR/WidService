using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ActivityType : IActivityType
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

