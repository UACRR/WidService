using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelEmployee
    {
        public int emplid { get; set; }
        public int custId { get; set; }
        public int positionCode { get; set; }
        public string relDocument { get; set; }

        [JsonIgnore]
        public Company cust { get; set; }
        [JsonIgnore]
        public Employee empl { get; set; }
        [JsonIgnore]
        public PositionType positionCodeNavigation { get; set; }
    }
}

