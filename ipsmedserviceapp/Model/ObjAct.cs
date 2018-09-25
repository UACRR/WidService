using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ObjAct
    {
        public ObjAct()
        {
            EtGenreRate = new HashSet<EtGenreRate>();
            EtGenreRole = new HashSet<EtGenreRole>();
            ObjActTr = new HashSet<ObjActTr>();
            ObjectRight = new HashSet<ObjectRight>();
            RelGenrePercent = new HashSet<RelGenrePercent>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<EtGenreRate> EtGenreRate { get; set; }
        public ICollection<EtGenreRole> EtGenreRole { get; set; }
        public ICollection<ObjActTr> ObjActTr { get; set; }
        public ICollection<ObjectRight> ObjectRight { get; set; }
        public ICollection<RelGenrePercent> RelGenrePercent { get; set; }
    }
}
