using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MediaSearchData : IMediaSearchData
    {
        public long id { get; set; }
        public int objId { get; set; }
        public int typeData { get; set; }
        public string alterName { get; set; }
        public string alterNameNormalize { get; set; }
    }
}

