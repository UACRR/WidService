using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Genre : IGenre
    {
        public Genre()
        {
            GenreTr = new HashSet<GenreTr>();
            RelGenreAdapt = new HashSet<RelGenreAdapt>();
            RelGenreMovie = new HashSet<RelGenreMovie>();
            RelGenreSerial = new HashSet<RelGenreSerial>();
            RelObjGenre = new HashSet<RelObjGenre>();
        }

        public int CategoryCode { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<GenreTr> GenreTr { get; set; }
        public ICollection<RelGenreAdapt> RelGenreAdapt { get; set; }
        public ICollection<RelGenreMovie> RelGenreMovie { get; set; }
        public ICollection<RelGenreSerial> RelGenreSerial { get; set; }
        public ICollection<RelObjGenre> RelObjGenre { get; set; }
    }
}

