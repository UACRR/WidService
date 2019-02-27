using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class KlR031 : IKlR031
    {
        public KlR031()
        {
            KlR030 = new ObservableListSource<KlR030>();
        }

        public short R031 { get; set; }
        public string R031NameUk { get; set; }
        public string R031NameRu { get; set; }
        public string R031NameEn { get; set; }

        public virtual ObservableListSource<KlR030> KlR030 { get; set; }
    }
}

