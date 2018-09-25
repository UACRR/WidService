using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MediaTrack : IMediaTrack
    {
        public MediaTrack()
        {
            MediaFile = new ObservableListSource<MediaFile>();
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

        public ObjectRight Obj { get; set; }
        public ObservableListSource<MediaFile> MediaFile { get; set; }
    }
}

