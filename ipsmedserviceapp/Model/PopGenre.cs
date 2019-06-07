using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PopGenre
    {
        public PopGenre()
        {
            PopGenreTr = new HashSet<PopGenreTr>();
            RelGenreAdapt = new HashSet<RelGenreAdapt>();
            RelGenreMovie = new HashSet<RelGenreMovie>();
            RelGenreSerial = new HashSet<RelGenreSerial>();
            RelPopGenre = new HashSet<RelPopGenre>();
        }

        public int CategoryCode { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ICollection<PopGenreTr> PopGenreTr { get; set; }
        public virtual ICollection<RelGenreAdapt> RelGenreAdapt { get; set; }
        public virtual ICollection<RelGenreMovie> RelGenreMovie { get; set; }
        public virtual ICollection<RelGenreSerial> RelGenreSerial { get; set; }
        public virtual ICollection<RelPopGenre> RelPopGenre { get; set; }
    }
}
