using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelMovieEpisode : IRelMovieEpisode
    {
        public int episodeTypeCode { get; set; }
        public int reqId { get; set; }
        public double? epDuration { get; set; }

        public EpisodeType episodeTypeCodeNavigation { get; set; }
        public RequestMovie req { get; set; }
    }
}

