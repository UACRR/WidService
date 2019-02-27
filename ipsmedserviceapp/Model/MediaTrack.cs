using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MediaTrack
    {
        public MediaTrack()
        {
            MediaFile = new HashSet<MediaFile>();
        }

        public int ObjId { get; set; }
        public string Iswc { get; set; }
        public string Name { get; set; }
        public string Lyrics { get; set; }
        public string Composers { get; set; }
        public string Performers { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public int? NumberInAlbum { get; set; }
        public int? Year { get; set; }
        public string Label { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public TimeSpan? Duration { get; set; }

        public virtual ObjectRight Obj { get; set; }
        public virtual ICollection<MediaFile> MediaFile { get; set; }
    }
}
