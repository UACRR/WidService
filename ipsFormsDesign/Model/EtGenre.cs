using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class EtGenre : IEtGenre
    {
        public EtGenre()
        {
            EtGenreRate = new ObservableListSource<EtGenreRate>();
            EtGenreRole = new ObservableListSource<EtGenreRole>();
            RelEtGenre = new ObservableListSource<RelEtGenre>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ObservableListSource<EtGenreRate> EtGenreRate { get; set; }
        public ObservableListSource<EtGenreRole> EtGenreRole { get; set; }
        public ObservableListSource<RelEtGenre> RelEtGenre { get; set; }
    }
}

