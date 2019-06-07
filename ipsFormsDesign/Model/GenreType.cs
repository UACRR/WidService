using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class GenreType : IGenreType
    {
        public GenreType()
        {
            GenreTypeTr = new ObservableListSource<GenreTypeTr>();
            RelEtGenre = new ObservableListSource<RelEtGenre>();
            RelGenrePercent = new ObservableListSource<RelGenrePercent>();
            RelGenreRole = new ObservableListSource<RelGenreRole>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ObservableListSource<GenreTypeTr> GenreTypeTr { get; set; }
        public virtual ObservableListSource<RelEtGenre> RelEtGenre { get; set; }
        public virtual ObservableListSource<RelGenrePercent> RelGenrePercent { get; set; }
        public virtual ObservableListSource<RelGenreRole> RelGenreRole { get; set; }
    }
}

