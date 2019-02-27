using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MediaFile : IMediaFile
    {
        public int MediaFileId { get; set; }
        public string FileType { get; set; }
        public string Path { get; set; }
        public double? Compress { get; set; }
        public double? PlayTime { get; set; }
        public int? ObjId { get; set; }

        public virtual MediaTrack Obj { get; set; }
    }
}

