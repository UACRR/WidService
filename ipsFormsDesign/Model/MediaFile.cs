using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MediaFile : IMediaFile
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

