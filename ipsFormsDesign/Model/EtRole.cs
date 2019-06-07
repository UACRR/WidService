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
            RelEtRole = new ObservableListSource<RelEtRole>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? CategoryCode { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ObservableListSource<EtGenreRole> EtGenreRole { get; set; }
        public virtual ObservableListSource<RelEtRole> RelEtRole { get; set; }
    }
}

