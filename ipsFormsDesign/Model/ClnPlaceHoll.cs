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
        public string ValuePlace { get; set; }
        public string ValueAdd { get; set; }

        public virtual ClnBusinessPlace Place { get; set; }
    }
}

