using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Company
    {
        public Company()
        {
            AnketaCompany = new HashSet<AnketaCompany>();
            RelEmployee = new HashSet<RelEmployee>();
        }

        public int CustId { get; set; }
        public int Version { get; set; }

        [JsonIgnore]
        public virtual Customer Cust { get; set; }
        public virtual ICollection<AnketaCompany> AnketaCompany { get; set; }
        public virtual ICollection<RelEmployee> RelEmployee { get; set; }
    }
}

