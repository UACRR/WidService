using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class GenreType
    {
        public GenreType()
        {
            GenreTypeTr = new HashSet<GenreTypeTr>();
            RelGenrePercent = new HashSet<RelGenrePercent>();
            relEtGenre = new HashSet<relEtGenre>();
            relGenreRole = new HashSet<relGenreRole>();
        }

        public int codeI { get; set; }
        public int categoryCode { get; set; }
        public string name { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ICollection<GenreTypeTr> GenreTypeTr { get; set; }
        public ICollection<RelGenrePercent> RelGenrePercent { get; set; }
        public ICollection<relEtGenre> relEtGenre { get; set; }
        public ICollection<relGenreRole> relGenreRole { get; set; }
    }
}
