using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MediaFile
    {
        public int mediaFileId { get; set; }
        public string fileType { get; set; }
        public string path { get; set; }
        public double? compress { get; set; }
        public double? playTime { get; set; }
        public int? objId { get; set; }

        public MediaTrack obj { get; set; }
    }
}
