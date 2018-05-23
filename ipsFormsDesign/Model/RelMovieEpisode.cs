using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelMovieEpisode : IRelMovieEpisode
    {
        public int EpisodeTypeCode { get; set; }
        public int ReqId { get; set; }
        public double? EpDuration { get; set; }

        public EpisodeType EpisodeTypeCodeNavigation { get; set; }
        public RequestMovie Req { get; set; }
    }
}

