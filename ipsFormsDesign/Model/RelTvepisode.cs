using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelTvepisode : IRelTvepisode
    {
        public int ReqId { get; set; }
        public int EpisodeTypeCode { get; set; }
        public double? EpDuration { get; set; }

        public virtual EpisodeType EpisodeTypeCodeNavigation { get; set; }
        public virtual RequestTvradio Req { get; set; }
    }
}

