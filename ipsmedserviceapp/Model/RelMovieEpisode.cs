using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelMovieEpisode
    {
        public int EpisodeTypeCode { get; set; }
        public int ReqId { get; set; }
        public double? EpDuration { get; set; }

        public virtual EpisodeType EpisodeTypeCodeNavigation { get; set; }
        public virtual RequestMovie Req { get; set; }
    }
}
