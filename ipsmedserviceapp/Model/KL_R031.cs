using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KL_R031
    {
        public KL_R031()
        {
            KL_R030 = new HashSet<KL_R030>();
        }

        public short r031 { get; set; }
        public string r031NameUk { get; set; }
        public string r031NameRu { get; set; }
        public string r031NameEn { get; set; }

        public ICollection<KL_R030> KL_R030 { get; set; }
    }
}
