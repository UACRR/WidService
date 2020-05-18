using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
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
            RhcatalogItem = new ObservableListSource<RhcatalogItem>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ObservableListSource<CatalogFile> CatalogFile { get; set; }
        public virtual ObservableListSource<CatalogStatusTr> CatalogStatusTr { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<PubCatalogItem> PubCatalogItem { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<RhcatalogItem> RhcatalogItem { get; set; }
    }
}


