using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MusicalDesign : IMusicalDesign
    {
        public int MdId { get; set; }
        public int LicId { get; set; }
        public int? Objid { get; set; }
        public int? ActNumb { get; set; }
        public string ObjName { get; set; }
        public string NameMusician { get; set; }
        public string NameSinger { get; set; }
        public decimal? Duration { get; set; }
        public int? NumbPerfom { get; set; }

        public LicenseBigR Lic { get; set; }
        public ObjectRight Obj { get; set; }
    }
}

