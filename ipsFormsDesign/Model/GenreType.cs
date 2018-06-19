using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class GenreType : IGenreType
    {
        public GenreType()
        {
            GenreTypeTr = new HashSet<GenreTypeTr>();
            RelEtGenre = new HashSet<RelEtGenre>();
            RelGenreRole = new HashSet<RelGenreRole>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<GenreTypeTr> GenreTypeTr { get; set; }
        public ICollection<RelEtGenre> RelEtGenre { get; set; }
        public ICollection<RelGenreRole> RelGenreRole { get; set; }
    }
}

