using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class EpisodeType
    {
        public EpisodeType()
        {
            RelMovieEpisode = new HashSet<RelMovieEpisode>();
            RelSerialEpisode = new HashSet<RelSerialEpisode>();
            RelTvepisode = new HashSet<RelTvepisode>();
        }

        public int EpisodeTypeCode { get; set; }
        public string EpisodeTypeNameUk { get; set; }
        public string EpisodeTypeNameRu { get; set; }
        public string EpisodeTypeNameEn { get; set; }

        public ICollection<RelMovieEpisode> RelMovieEpisode { get; set; }
        public ICollection<RelSerialEpisode> RelSerialEpisode { get; set; }
        public ICollection<RelTvepisode> RelTvepisode { get; set; }
    }
}
