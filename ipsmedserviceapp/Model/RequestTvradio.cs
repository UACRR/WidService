using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestTVRadio
    {
        public RequestTVRadio()
        {
            RelTVEpisode = new HashSet<RelTVEpisode>();
        }

        public int reqId { get; set; }
        public string shortTitle { get; set; }
        public string nameTVChanel { get; set; }
        public string episodeComment { get; set; }

        public Request req { get; set; }
        public ICollection<RelTVEpisode> RelTVEpisode { get; set; }
    }
}
