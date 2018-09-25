using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DocText : IDocText
    {
        public int Id { get; set; }
        public int? DocTypeCode { get; set; }
        public string Code { get; set; }
        public string Text_Uk { get; set; }
        public string Text_Ru { get; set; }
        public string Text_En { get; set; }
    }
}

