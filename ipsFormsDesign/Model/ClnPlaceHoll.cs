using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ClnPlaceHoll : IClnPlaceHoll
    {
        public int hollId { get; set; }
        public int? placeId { get; set; }
        public string hollName { get; set; }
        public string valuePlace { get; set; }
        public string valueAdd { get; set; }

        public ClnBusinessPlace place { get; set; }
    }
}

