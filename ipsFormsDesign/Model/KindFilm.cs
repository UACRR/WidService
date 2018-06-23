using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class KindFilm : IKindFilm
    {
        public KindFilm()
        {
            KindFilmTr = new ObservableListSource<KindFilmTr>();
            RequestMovie = new ObservableListSource<RequestMovie>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<KindFilmTr> KindFilmTr { get; set; }
        public ObservableListSource<RequestMovie> RequestMovie { get; set; }
    }
}

