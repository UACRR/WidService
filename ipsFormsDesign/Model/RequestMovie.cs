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

        public int reqId { get; set; }
        public int? kindFilm { get; set; }
        public string episodeComment { get; set; }
        public bool? UseHire { get; set; }
        public bool? UseFestival { get; set; }

        public KindFilm kindFilmNavigation { get; set; }
        public Request req { get; set; }
        public ObservableListSource<RelGenreMovie> RelGenreMovie { get; set; }
        public ObservableListSource<RelMovieEpisode> RelMovieEpisode { get; set; }
    }
}

