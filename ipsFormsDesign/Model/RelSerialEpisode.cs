using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelSerialEpisode : IRelSerialEpisode
    {
        public int ReqId { get; set; }
        public int EpisodeTypeCode { get; set; }
        public double? EpDuration { get; set; }

        public virtual EpisodeType EpisodeTypeCodeNavigation { get; set; }
        public virtual RequestSerial Req { get; set; }
    }
}

