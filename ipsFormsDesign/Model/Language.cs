using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Language : ILanguage
    {
        public Language()
        {
            CopyRtranslateLangFromNavigation = new ObservableListSource<CopyRtranslate>();
            CopyRtranslateLangToNavigation = new ObservableListSource<CopyRtranslate>();
            LicenseBigR = new ObservableListSource<LicenseBigR>();
        }

        public string CodeS { get; set; }
        public string Name { get; set; }
        public int? NameId { get; set; }
        public string NameSh3 { get; set; }
        public short? ShortChoise { get; set; }

        public ObservableListSource<CopyRtranslate> CopyRtranslateLangFromNavigation { get; set; }
        public ObservableListSource<CopyRtranslate> CopyRtranslateLangToNavigation { get; set; }
        public ObservableListSource<LicenseBigR> LicenseBigR { get; set; }
    }
}

