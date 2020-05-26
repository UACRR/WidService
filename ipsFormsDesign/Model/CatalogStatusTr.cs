using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CatalogStatusTr : ICatalogStatusTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual CatalogStatus CodeINavigation { get; set; }
    }
}




