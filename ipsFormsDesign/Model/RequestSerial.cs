using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestSerial : IRequestSerial
    {
        public RequestSerial()
        {
            RelGenreSerial = new ObservableListSource<RelGenreSerial>();
            RelSerialEpisode = new ObservableListSource<RelSerialEpisode>();
        }

        public int reqId { get; set; }
        public int? kindSerial { get; set; }
        public string episodeComment { get; set; }
        public short? cntSeries { get; set; }
        public bool? UseHire { get; set; }
        public bool? UseFestival { get; set; }

        public KindSerial kindSerialNavigation { get; set; }
        public Request req { get; set; }
        public ObservableListSource<RelGenreSerial> RelGenreSerial { get; set; }
        public ObservableListSource<RelSerialEpisode> RelSerialEpisode { get; set; }
    }
}

