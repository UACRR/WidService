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

        public Request Req { get; set; }
        public ObservableListSource<RelTvepisode> RelTvepisode { get; set; }
    }
}

