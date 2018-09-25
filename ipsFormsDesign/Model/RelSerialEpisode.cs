using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelSerialEpisode : IRelSerialEpisode
    {
        public int reqId { get; set; }
        public int episodeTypeCode { get; set; }
        public double? epDuration { get; set; }

        public EpisodeType episodeTypeCodeNavigation { get; set; }
        public RequestSerial req { get; set; }
    }
}

