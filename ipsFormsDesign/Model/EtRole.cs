using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class EtRole : IEtRole
    {
        public EtRole()
        {
            EtGenreRole = new ObservableListSource<EtGenreRole>();
            relEtRole = new ObservableListSource<relEtRole>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public int? categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ObservableListSource<EtGenreRole> EtGenreRole { get; set; }
        public ObservableListSource<relEtRole> relEtRole { get; set; }
    }
}

