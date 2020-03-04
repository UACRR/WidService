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
        public string Lang1 { get; set; }

        public virtual ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
        public virtual ObservableListSource<LangTr> LangTr { get; set; }
    }
}

