using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestMovie
    {
        public RequestMovie()
        {
            RelGenreMovie = new HashSet<RelGenreMovie>();
            RelMovieEpisode = new HashSet<RelMovieEpisode>();
        }

        public int ReqId { get; set; }
        public int? KindFilm { get; set; }
        public string EpisodeComment { get; set; }
        public bool? UseHire { get; set; }
        public bool? UseFestival { get; set; }

        public virtual KindFilm KindFilmNavigation { get; set; }
        public virtual Request Req { get; set; }
        public virtual ICollection<RelGenreMovie> RelGenreMovie { get; set; }
        public virtual ICollection<RelMovieEpisode> RelMovieEpisode { get; set; }
    }
}
