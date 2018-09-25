using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelTVEpisode : IRelTVEpisode
    {
        public int reqId { get; set; }
        public int episodeTypeCode { get; set; }
        public double? epDuration { get; set; }

        public EpisodeType episodeTypeCodeNavigation { get; set; }
        public RequestTVRadio req { get; set; }
    }
}

