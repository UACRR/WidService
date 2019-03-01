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
            RelTvepisode = new HashSet<RelTvepisode>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EpisodeTypeTr> EpisodeTypeTr { get; set; }
        public virtual ICollection<RelMovieEpisode> RelMovieEpisode { get; set; }
        public virtual ICollection<RelSerialEpisode> RelSerialEpisode { get; set; }
        public virtual ICollection<RelTvepisode> RelTvepisode { get; set; }
    }
}
