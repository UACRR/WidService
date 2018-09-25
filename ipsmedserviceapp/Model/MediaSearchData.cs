using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MediaSearchData
    {
        public long id { get; set; }
        public int objId { get; set; }
        public int typeData { get; set; }
        public string alterName { get; set; }
        public string alterNameNormalize { get; set; }
    }
}
