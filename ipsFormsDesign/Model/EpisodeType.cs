using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class EpisodeType : IEpisodeType
    {
        public EpisodeType()
        {
            EpisodeTypeTr = new ObservableListSource<EpisodeTypeTr>();
            RelMovieEpisode = new ObservableListSource<RelMovieEpisode>();
            RelSerialEpisode = new ObservableListSource<RelSerialEpisode>();
            RelTVEpisode = new ObservableListSource<RelTVEpisode>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<EpisodeTypeTr> EpisodeTypeTr { get; set; }
        public ObservableListSource<RelMovieEpisode> RelMovieEpisode { get; set; }
        public ObservableListSource<RelSerialEpisode> RelSerialEpisode { get; set; }
        public ObservableListSource<RelTVEpisode> RelTVEpisode { get; set; }
    }
}

