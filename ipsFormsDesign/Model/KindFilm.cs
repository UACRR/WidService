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

        public virtual ObservableListSource<KindFilmTr> KindFilmTr { get; set; }
        public virtual ObservableListSource<RequestMovie> RequestMovie { get; set; }
    }
}

