using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelTvepisode : IRelTvepisode
    {
        public int ReqId { get; set; }
        public int EpisodeTypeCode { get; set; }
        public double? EpDuration { get; set; }

        public EpisodeType EpisodeTypeCodeNavigation { get; set; }
        public RequestTvradio Req { get; set; }
    }
}

