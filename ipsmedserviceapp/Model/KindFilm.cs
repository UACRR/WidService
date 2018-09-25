using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KindFilm
    {
        public KindFilm()
        {
            KindFilmTr = new HashSet<KindFilmTr>();
            RequestMovie = new HashSet<RequestMovie>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<KindFilmTr> KindFilmTr { get; set; }
        public ICollection<RequestMovie> RequestMovie { get; set; }
    }
}
