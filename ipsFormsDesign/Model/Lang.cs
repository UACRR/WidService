using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Lang : ILang
    {
        public Lang()
        {
            AnketaPerson = new HashSet<AnketaPerson>();
            LangTr = new HashSet<LangTr>();
        }

        public string CodeS { get; set; }
        public string Name { get; set; }

        public ICollection<AnketaPerson> AnketaPerson { get; set; }
        public ICollection<LangTr> LangTr { get; set; }
    }
}

