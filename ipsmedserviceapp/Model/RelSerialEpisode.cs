using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelSerialEpisode
    {
        public int reqId { get; set; }
        public int episodeTypeCode { get; set; }
        public double? epDuration { get; set; }

        public EpisodeType episodeTypeCodeNavigation { get; set; }
        public RequestSerial req { get; set; }
    }
}
