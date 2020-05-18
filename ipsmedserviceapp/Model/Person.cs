using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Person
    {
        public Person()
        {
            AnketaPerson = new HashSet<AnketaPerson>();
        }

        public int CustId { get; set; }
        public int Version { get; set; }

        [JsonIgnore]
        public virtual Customer Cust { get; set; }
        public virtual ICollection<AnketaPerson> AnketaPerson { get; set; }
    }
}


