using System;

namespace IPSViewComponentLibraryWPF.Modules.CatalogFileItems.Controls.PubCatalogItem
{
    public class PubCatalogItemModel
    {
        public string ItemCode { get; set; }
        public string Iswc { get; set; }
        public string ObjName { get; set; }
        public string GenreName { get; set; }
        public string RoleName { get; set; }
        public decimal? Rate { get; set; }
        public decimal? RateMech { get; set; }
        public string AuthorMusic { get; set; }
        public string AuthorText { get; set; }
        public string Performer { get; set; }
        public string ErrComment { get; set; }
        public string RhName { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
