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
        public Customer Cust { get; set; }
        public ICollection<AnketaCompany> AnketaCompany { get; set; }
        public ICollection<RelEmployee> RelEmployee { get; set; }
    }
}











