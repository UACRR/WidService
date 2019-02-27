using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestTvradio
    {
        public RequestTvradio()
        {
            RelTvepisode = new HashSet<RelTvepisode>();
        }

        public int ReqId { get; set; }
        public string ShortTitle { get; set; }
        public string NameTvchanel { get; set; }
        public string EpisodeComment { get; set; }

        public virtual Request Req { get; set; }
        public virtual ICollection<RelTvepisode> RelTvepisode { get; set; }
    }
}
