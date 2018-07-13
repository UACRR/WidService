using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ClnPlaceHoll
    {
        public int HollId { get; set; }
        public int? PlaceId { get; set; }
        public string HollName { get; set; }
        public string ValuePlace { get; set; }
        public string ValueAdd { get; set; }

        public ClnBusinessPlace Place { get; set; }
    }
}
