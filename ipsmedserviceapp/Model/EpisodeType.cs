using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class EpisodeType
    {
        public EpisodeType()
        {
            EpisodeTypeTr = new HashSet<EpisodeTypeTr>();
            RelMovieEpisode = new HashSet<RelMovieEpisode>();
            RelSerialEpisode = new HashSet<RelSerialEpisode>();
            RelTVEpisode = new HashSet<RelTVEpisode>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<EpisodeTypeTr> EpisodeTypeTr { get; set; }
        public ICollection<RelMovieEpisode> RelMovieEpisode { get; set; }
        public ICollection<RelSerialEpisode> RelSerialEpisode { get; set; }
        public ICollection<RelTVEpisode> RelTVEpisode { get; set; }
    }
}
