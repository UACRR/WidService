using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CreativeTranslate : ICreativeTranslate
    {
        public CreativeTranslate()
        {
            CopyRTranslate = new ObservableListSource<CopyRTranslate>();
        }

        public int codeI { get; set; }

        public CreativeRoleType codeINavigation { get; set; }
        public ObservableListSource<CopyRTranslate> CopyRTranslate { get; set; }
    }
}

