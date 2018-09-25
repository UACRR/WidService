using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Language : ILanguage
    {
        public Language()
        {
            CopyRTranslatelangFromNavigation = new ObservableListSource<CopyRTranslate>();
            CopyRTranslatelangToNavigation = new ObservableListSource<CopyRTranslate>();
            LicenseBigR = new ObservableListSource<LicenseBigR>();
        }

        public string codeS { get; set; }
        public string name { get; set; }
        public int? nameId { get; set; }
        public string nameSh3 { get; set; }
        public short? shortChoise { get; set; }

        public ObservableListSource<CopyRTranslate> CopyRTranslatelangFromNavigation { get; set; }
        public ObservableListSource<CopyRTranslate> CopyRTranslatelangToNavigation { get; set; }
        public ObservableListSource<LicenseBigR> LicenseBigR { get; set; }
    }
}

