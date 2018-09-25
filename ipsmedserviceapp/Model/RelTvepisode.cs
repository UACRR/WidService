using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelTVEpisode
    {
        public int reqId { get; set; }
        public int episodeTypeCode { get; set; }
        public double? epDuration { get; set; }

        public EpisodeType episodeTypeCodeNavigation { get; set; }
        public RequestTVRadio req { get; set; }
    }
}
