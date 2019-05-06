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
            CatalogStatusTr = new ObservableListSource<CatalogStatusTr>();
            PubCatalogItem = new ObservableListSource<PubCatalogItem>();
            RhñatalogItem = new ObservableListSource<RhñatalogItem>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<CatalogFile> CatalogFile { get; set; }
        public virtual ObservableListSource<CatalogStatusTr> CatalogStatusTr { get; set; }
        public virtual ObservableListSource<PubCatalogItem> PubCatalogItem { get; set; }
        public virtual ObservableListSource<RhñatalogItem> RhñatalogItem { get; set; }
    }
}

