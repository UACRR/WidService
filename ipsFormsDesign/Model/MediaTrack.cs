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

        public int objId { get; set; }
        public string iswc { get; set; }
        public string name { get; set; }
        public string lyrics { get; set; }
        public string composers { get; set; }
        public string performers { get; set; }
        public string Album { get; set; }
        public string genre { get; set; }
        public int? numberInAlbum { get; set; }
        public int? year { get; set; }
        public string label { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public TimeSpan? duration { get; set; }

        public ObjectRight obj { get; set; }
        public ObservableListSource<MediaFile> MediaFile { get; set; }
    }
}

