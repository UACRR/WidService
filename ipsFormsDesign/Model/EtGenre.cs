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
            relEtGenre = new ObservableListSource<relEtGenre>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public int? categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ObservableListSource<EtGenreRate> EtGenreRate { get; set; }
        public ObservableListSource<EtGenreRole> EtGenreRole { get; set; }
        public ObservableListSource<relEtGenre> relEtGenre { get; set; }
    }
}

