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

        public virtual ICollection<EtGenreRate> EtGenreRate { get; set; }
        public virtual ICollection<EtGenreRole> EtGenreRole { get; set; }
        public virtual ICollection<ObjActTr> ObjActTr { get; set; }
        public virtual ICollection<ObjectRight> ObjectRight { get; set; }
        public virtual ICollection<RelGenrePercent> RelGenrePercent { get; set; }
    }
}
