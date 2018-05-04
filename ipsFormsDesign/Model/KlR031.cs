using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KlR031
    {
        public KlR031()
        {
            KlR030 = new HashSet<KlR030>();
        }

        public short R031 { get; set; }
        public string R031NameUk { get; set; }
        public string R031NameRu { get; set; }
        public string R031NameEn { get; set; }

        public ICollection<KlR030> KlR030 { get; set; }
    }
}
