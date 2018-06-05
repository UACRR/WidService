using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ObjAct : IObjAct
    {
        public ObjAct()
        {
            EtGenreRate = new HashSet<EtGenreRate>();
            EtGenreRole = new HashSet<EtGenreRole>();
            ObjActTr = new HashSet<ObjActTr>();
            ObjectRight = new HashSet<ObjectRight>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<EtGenreRate> EtGenreRate { get; set; }
        public ICollection<EtGenreRole> EtGenreRole { get; set; }
        public ICollection<ObjActTr> ObjActTr { get; set; }
        public ICollection<ObjectRight> ObjectRight { get; set; }
    }
}

