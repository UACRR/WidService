using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CreativeTranslate : ICreativeTranslate
    {
        public CreativeTranslate()
        {
            CopyRtranslate = new ObservableListSource<CopyRtranslate>();
        }

        public int CodeI { get; set; }

        public CreativeRoleType CodeINavigation { get; set; }
        public ObservableListSource<CopyRtranslate> CopyRtranslate { get; set; }
    }
}

