using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KlR030tr : IKlR030tr
    {
        public string R030 { get; set; }
        public string Lang { get; set; }
        public string R030Name { get; set; }

        public KlR030 R030Navigation { get; set; }
    }
}

