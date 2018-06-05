using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ClnPlaceHoll : IClnPlaceHoll
    {
        public int HollId { get; set; }
        public int? PlaceId { get; set; }
        public string HollName { get; set; }
        public int? HollNum { get; set; }
        public bool? ÑalcNum { get; set; }
        public decimal? SqHoll { get; set; }

        public ClnBusinessPlace Place { get; set; }
    }
}

