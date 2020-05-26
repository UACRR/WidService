using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelEmployee
    {
        public int Emplid { get; set; }
        public int CustId { get; set; }
        public int PositionCode { get; set; }
        public string RelDocument { get; set; }

        [JsonIgnore]
        public virtual Company Cust { get; set; }
        public virtual Employee Empl { get; set; }
        [JsonIgnore]
        public virtual PositionType PositionCodeNavigation { get; set; }
    }
}


