using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PopGenre : IPopGenre
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

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<PopGenreTr> PopGenreTr { get; set; }
        public ICollection<RelGenreAdapt> RelGenreAdapt { get; set; }
        public ICollection<RelGenreMovie> RelGenreMovie { get; set; }
        public ICollection<RelGenreSerial> RelGenreSerial { get; set; }
        public ICollection<RelPopGenre> RelPopGenre { get; set; }
    }
}

