using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ObjAct : IObjAct
    {
        public ObjAct()
        {
            EtGenreRate = new ObservableListSource<EtGenreRate>();
            EtGenreRole = new ObservableListSource<EtGenreRole>();
            ObjActTr = new ObservableListSource<ObjActTr>();
            ObjectRight = new ObservableListSource<ObjectRight>();
            RelGenrePercent = new ObservableListSource<RelGenrePercent>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<EtGenreRate> EtGenreRate { get; set; }
        public ObservableListSource<EtGenreRole> EtGenreRole { get; set; }
        public ObservableListSource<ObjActTr> ObjActTr { get; set; }
        public ObservableListSource<ObjectRight> ObjectRight { get; set; }
        public ObservableListSource<RelGenrePercent> RelGenrePercent { get; set; }
    }
}

