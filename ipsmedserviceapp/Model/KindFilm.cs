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

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<KindFilmTr> KindFilmTr { get; set; }
        public virtual ICollection<RequestMovie> RequestMovie { get; set; }
    }
}
