using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelSerialEpisode
    {
        public int ReqId { get; set; }
        public int EpisodeTypeCode { get; set; }
        public double? EpDuration { get; set; }

        public EpisodeType EpisodeTypeCodeNavigation { get; set; }
        public RequestSerial Req { get; set; }
    }
}
