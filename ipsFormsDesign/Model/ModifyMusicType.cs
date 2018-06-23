using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ModifyMusicType : IModifyMusicType
    {
        public ModifyMusicType()
        {
            ModifyMusicTypeTr = new ObservableListSource<ModifyMusicTypeTr>();
            RequestAdapt = new ObservableListSource<RequestAdapt>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? KindCompCode { get; set; }
        public int CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public KindComposition KindCompCodeNavigation { get; set; }
        public ObservableListSource<ModifyMusicTypeTr> ModifyMusicTypeTr { get; set; }
        public ObservableListSource<RequestAdapt> RequestAdapt { get; set; }
    }
}

