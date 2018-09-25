using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LangTr : ILangTr
    {
        public string codeS { get; set; }
        public string lang { get; set; }
        public string name { get; set; }

        public Lang codeSNavigation { get; set; }
    }
}

