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
            RelGenrePercent = new ObservableListSource<RelGenrePercent>();
            relEtGenre = new ObservableListSource<relEtGenre>();
            relGenreRole = new ObservableListSource<relGenreRole>();
        }

        public int codeI { get; set; }
        public int categoryCode { get; set; }
        public string name { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ObservableListSource<GenreTypeTr> GenreTypeTr { get; set; }
        public ObservableListSource<RelGenrePercent> RelGenrePercent { get; set; }
        public ObservableListSource<relEtGenre> relEtGenre { get; set; }
        public ObservableListSource<relGenreRole> relGenreRole { get; set; }
    }
}

