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
            RelTvepisode = new ObservableListSource<RelTvepisode>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<EpisodeTypeTr> EpisodeTypeTr { get; set; }
        public virtual ObservableListSource<RelMovieEpisode> RelMovieEpisode { get; set; }
        public virtual ObservableListSource<RelSerialEpisode> RelSerialEpisode { get; set; }
        public virtual ObservableListSource<RelTvepisode> RelTvepisode { get; set; }
    }
}

