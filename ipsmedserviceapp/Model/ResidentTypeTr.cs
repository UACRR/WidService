using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ResidentTypeTr
    {
        public int ResidentCode { get; set; }
        public string Lang { get; set; }
        public string ResidentName { get; set; }

        public ResidentType ResidentCodeNavigation { get; set; }
    }
}
