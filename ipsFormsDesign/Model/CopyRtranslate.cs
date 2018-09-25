using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CopyRTranslate : ICopyRTranslate
    {
        public int cRightId { get; set; }
        public int? roleCode { get; set; }
        public string langFrom { get; set; }
        public string langTo { get; set; }

        public CopyRight cRight { get; set; }
        public Language langFromNavigation { get; set; }
        public Language langToNavigation { get; set; }
        public CreativeTranslate roleCodeNavigation { get; set; }
    }
}

