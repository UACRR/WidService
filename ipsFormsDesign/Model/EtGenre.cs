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

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ObservableListSource<EtGenreRate> EtGenreRate { get; set; }
        public virtual ObservableListSource<EtGenreRole> EtGenreRole { get; set; }
        public virtual ObservableListSource<RelEtGenre> RelEtGenre { get; set; }
    }
}

