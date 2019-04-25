using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CatalogStatus : ICatalogStatus
    {
        public CatalogStatus()
        {
            CatalogFile = new ObservableListSource<CatalogFile>();
            PubÑatalogItem = new ObservableListSource<PubÑatalogItem>();
            RhñatalogItem = new ObservableListSource<RhñatalogItem>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<CatalogFile> CatalogFile { get; set; }
        public virtual ObservableListSource<PubÑatalogItem> PubÑatalogItem { get; set; }
        public virtual ObservableListSource<RhñatalogItem> RhñatalogItem { get; set; }
    }
}

