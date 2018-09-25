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

        public int ReqId { get; set; }
        public int? KindSerial { get; set; }
        public string EpisodeComment { get; set; }
        public short? CntSeries { get; set; }
        public bool? UseHire { get; set; }
        public bool? UseFestival { get; set; }

        public KindSerial KindSerialNavigation { get; set; }
        public Request Req { get; set; }
        public ObservableListSource<RelGenreSerial> RelGenreSerial { get; set; }
        public ObservableListSource<RelSerialEpisode> RelSerialEpisode { get; set; }
    }
}

