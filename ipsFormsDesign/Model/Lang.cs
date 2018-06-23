using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Lang : ILang
    {
        public Lang()
        {
            AnketaPerson = new ObservableListSource<AnketaPerson>();
            LangTr = new ObservableListSource<LangTr>();
        }

        public string CodeS { get; set; }
        public string Name { get; set; }

        public ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public ObservableListSource<LangTr> LangTr { get; set; }
    }
}

