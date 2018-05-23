using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class EpisodeType : IEpisodeType
    {
        public EpisodeType()
        {
            EpisodeTypeTr = new HashSet<EpisodeTypeTr>();
            RelMovieEpisode = new HashSet<RelMovieEpisode>();
            RelSerialEpisode = new HashSet<RelSerialEpisode>();
            RelTvepisode = new HashSet<RelTvepisode>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<EpisodeTypeTr> EpisodeTypeTr { get; set; }
        public ICollection<RelMovieEpisode> RelMovieEpisode { get; set; }
        public ICollection<RelSerialEpisode> RelSerialEpisode { get; set; }
        public ICollection<RelTvepisode> RelTvepisode { get; set; }
    }
}

