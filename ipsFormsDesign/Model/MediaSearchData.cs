using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MediaSearchData : IMediaSearchData
    {
        public long Id { get; set; }
        public int ObjId { get; set; }
        public int TypeData { get; set; }
        public string AlterName { get; set; }
        public string AlterNameNormalize { get; set; }
    }
}

