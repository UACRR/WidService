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

        public int reqId { get; set; }
        public int? kindFilm { get; set; }
        public string episodeComment { get; set; }
        public bool? UseHire { get; set; }
        public bool? UseFestival { get; set; }

        public KindFilm kindFilmNavigation { get; set; }
        public Request req { get; set; }
        public ICollection<RelGenreMovie> RelGenreMovie { get; set; }
        public ICollection<RelMovieEpisode> RelMovieEpisode { get; set; }
    }
}
