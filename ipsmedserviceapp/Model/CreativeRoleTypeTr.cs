using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CreativeRoleTypeTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual CreativeRoleType CodeINavigation { get; set; }
    }
}




