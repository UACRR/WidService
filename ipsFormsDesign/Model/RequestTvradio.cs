using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestTvradio : IRequestTvradio
    {
        public RequestTvradio()
        {
            RelTvepisode = new ObservableListSource<RelTvepisode>();
        }

        public int ReqId { get; set; }
        public string ShortTitle { get; set; }
        public string NameTvchanel { get; set; }
        public string EpisodeComment { get; set; }

        public virtual Request Req { get; set; }
        public virtual ObservableListSource<RelTvepisode> RelTvepisode { get; set; }
    }
}

