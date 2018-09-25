using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestSerial
    {
        public RequestSerial()
        {
            RelGenreSerial = new HashSet<RelGenreSerial>();
            RelSerialEpisode = new HashSet<RelSerialEpisode>();
        }

        public int reqId { get; set; }
        public int? kindSerial { get; set; }
        public string episodeComment { get; set; }
        public short? cntSeries { get; set; }
        public bool? UseHire { get; set; }
        public bool? UseFestival { get; set; }

        public KindSerial kindSerialNavigation { get; set; }
        public Request req { get; set; }
        public ICollection<RelGenreSerial> RelGenreSerial { get; set; }
        public ICollection<RelSerialEpisode> RelSerialEpisode { get; set; }
    }
}
