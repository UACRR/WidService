using System;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model
{
    public class ObjectsRightOfRightholder
    {
        public bool IsSelected { get; set; }
        public int ObjId { get; set; }
        public string InnerCode { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string GenreName { get; set; }
        public TimeSpan? Duration { get; set; }
        public string SpecName { get; set; }
        public double RateTotal { get; set; }
        public string Author { get; set; }
        public string Performer { get; set; }
        public double Profit { get; set; }
        public int CategoryCode { get; set; }
        public int? Wic { get; set; }

        public int CustId { get; set; }
        public int? CRightId { get; set; }
        public string NameClient { get; set; }
        public string RoleName { get; set; }
        public decimal? RateRh { get; set; }
    }
}
