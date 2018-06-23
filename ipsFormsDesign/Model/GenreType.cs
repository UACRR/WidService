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
            RelGenreRole = new ObservableListSource<RelGenreRole>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ObservableListSource<GenreTypeTr> GenreTypeTr { get; set; }
        public ObservableListSource<RelEtGenre> RelEtGenre { get; set; }
        public ObservableListSource<RelGenreRole> RelGenreRole { get; set; }
    }
}

