using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KindFilm
    {
        public KindFilm()
        {
            RequestMovie = new HashSet<RequestMovie>();
        }

        public int KindFilmCode { get; set; }
        public string KindFilmNameUk { get; set; }
        public string KindFilmNameRu { get; set; }
        public string KindFilmNameEn { get; set; }

        public ICollection<RequestMovie> RequestMovie { get; set; }
    }
}
