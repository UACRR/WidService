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

        public int ReqId { get; set; }
        public int? KindSerial { get; set; }
        public string EpisodeComment { get; set; }
        public short? CntSeries { get; set; }
        public bool? UseHire { get; set; }
        public bool? UseFestival { get; set; }

        public virtual KindSerial KindSerialNavigation { get; set; }
        public virtual Request Req { get; set; }
        public virtual ICollection<RelGenreSerial> RelGenreSerial { get; set; }
        public virtual ICollection<RelSerialEpisode> RelSerialEpisode { get; set; }
    }
}
