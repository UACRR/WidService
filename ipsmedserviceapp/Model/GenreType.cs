using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class GenreType
    {
        public GenreType()
        {
            GenreTypeTr = new HashSet<GenreTypeTr>();
            RelEtGenre = new HashSet<RelEtGenre>();
            RelGenrePercent = new HashSet<RelGenrePercent>();
            RelGenreRole = new HashSet<RelGenreRole>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<GenreTypeTr> GenreTypeTr { get; set; }
        public ICollection<RelEtGenre> RelEtGenre { get; set; }
        public ICollection<RelGenrePercent> RelGenrePercent { get; set; }
        public ICollection<RelGenreRole> RelGenreRole { get; set; }
    }
}
