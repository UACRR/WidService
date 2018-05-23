using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestSerial : IRequestSerial
    {
        public RequestSerial()
        {
            RelGenreSerial = new HashSet<RelGenreSerial>();
            RelSerialEpisode = new HashSet<RelSerialEpisode>();
        }

        public int ReqId { get; set; }
        public int? KindSerial { get; set; }
        public string EpisodeComment { get; set; }
        public short? CntSeries { get; set; }
        public bool? UseHire { get; set; }
        public bool? UseFestival { get; set; }

        public KindSerial KindSerialNavigation { get; set; }
        public Request Req { get; set; }
        public ICollection<RelGenreSerial> RelGenreSerial { get; set; }
        public ICollection<RelSerialEpisode> RelSerialEpisode { get; set; }
    }
}

