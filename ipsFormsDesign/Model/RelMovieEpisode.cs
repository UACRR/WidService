using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelMovieEpisode : IRelMovieEpisode
    {
        public int EpisodeTypeCode { get; set; }
        public int ReqId { get; set; }
        public double? EpDuration { get; set; }

        public virtual EpisodeType EpisodeTypeCodeNavigation { get; set; }
        public virtual RequestMovie Req { get; set; }
    }
}

