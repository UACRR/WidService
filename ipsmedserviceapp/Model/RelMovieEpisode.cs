using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelMovieEpisode
    {
        public int episodeTypeCode { get; set; }
        public int reqId { get; set; }
        public double? epDuration { get; set; }

        public EpisodeType episodeTypeCodeNavigation { get; set; }
        public RequestMovie req { get; set; }
    }
}
