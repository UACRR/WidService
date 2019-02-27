using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Language : ILanguage
    {
        public Language()
        {
            LicenseBigR = new ObservableListSource<LicenseBigR>();
        }

        public string CodeS { get; set; }
        public string Name { get; set; }
        public int? NameId { get; set; }
        public string NameSh3 { get; set; }
        public short? ShortChoise { get; set; }

        public virtual ObservableListSource<LicenseBigR> LicenseBigR { get; set; }
    }
}

