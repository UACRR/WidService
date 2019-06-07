using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestMovie : IRequestMovie
    {
        public RequestMovie()
        {
            RelGenreMovie = new ObservableListSource<RelGenreMovie>();
            RelMovieEpisode = new ObservableListSource<RelMovieEpisode>();
        }

        public int ReqId { get; set; }
        public int? KindFilm { get; set; }
        public string EpisodeComment { get; set; }
        public bool? UseHire { get; set; }
        public bool? UseFestival { get; set; }

        public virtual KindFilm KindFilmNavigation { get; set; }
        public virtual Request Req { get; set; }
        public virtual ObservableListSource<RelGenreMovie> RelGenreMovie { get; set; }
        public virtual ObservableListSource<RelMovieEpisode> RelMovieEpisode { get; set; }
    }
}

