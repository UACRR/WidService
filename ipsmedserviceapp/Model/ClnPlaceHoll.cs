using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ClnPlaceHoll
    {
        public int hollId { get; set; }
        public int? placeId { get; set; }
        public string hollName { get; set; }
        public string valuePlace { get; set; }
        public string valueAdd { get; set; }

        public ClnBusinessPlace place { get; set; }
    }
}
