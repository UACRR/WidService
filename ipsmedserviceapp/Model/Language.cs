using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Language
    {
        public Language()
        {
            LicenseBigR = new HashSet<LicenseBigR>();
        }

        public string CodeS { get; set; }
        public string Name { get; set; }
        public int? NameId { get; set; }
        public string NameSh3 { get; set; }
        public short? ShortChoise { get; set; }

        public virtual ICollection<LicenseBigR> LicenseBigR { get; set; }
    }
}
