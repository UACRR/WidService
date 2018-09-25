using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestTVRadio : IRequestTVRadio
    {
        public RequestTVRadio()
        {
            RelTVEpisode = new ObservableListSource<RelTVEpisode>();
        }

        public int reqId { get; set; }
        public string shortTitle { get; set; }
        public string nameTVChanel { get; set; }
        public string episodeComment { get; set; }

        public Request req { get; set; }
        public ObservableListSource<RelTVEpisode> RelTVEpisode { get; set; }
    }
}

