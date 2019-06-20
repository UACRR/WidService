using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class GenreType
    {
        public GenreType()
        {
            GenreTypeTr = new HashSet<GenreTypeTr>();
            RegisterItem = new HashSet<RegisterItem>();
            RelEtGenre = new HashSet<RelEtGenre>();
            RelGenrePercent = new HashSet<RelGenrePercent>();
            RelGenreRole = new HashSet<RelGenreRole>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ICollection<GenreTypeTr> GenreTypeTr { get; set; }
        public virtual ICollection<RegisterItem> RegisterItem { get; set; }
        public virtual ICollection<RelEtGenre> RelEtGenre { get; set; }
        public virtual ICollection<RelGenrePercent> RelGenrePercent { get; set; }
        public virtual ICollection<RelGenreRole> RelGenreRole { get; set; }
    }
}
