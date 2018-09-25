using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FolkType : IFolkType
    {
        public FolkType()
        {
            Authors = new ObservableListSource<Authors>();
            FolkTypeTr = new ObservableListSource<FolkTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<Authors> Authors { get; set; }
        public ObservableListSource<FolkTypeTr> FolkTypeTr { get; set; }
    }
}

