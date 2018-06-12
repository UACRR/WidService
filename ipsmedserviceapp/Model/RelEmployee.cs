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
        public Company Cust { get; set; }
        public Employee Empl { get; set; }
        [JsonIgnore]
        public PositionType PositionCodeNavigation { get; set; }
    }
}



