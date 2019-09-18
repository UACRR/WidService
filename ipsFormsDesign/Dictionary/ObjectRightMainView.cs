using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectRightMainView
    {
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
    }

    public class ObjectRightForRightholder : ObjectRightMainView
    {
        public int CustId { get; set; }
        public int? CRightId { get; set; }
        public string NameClient { get; set; }
        public string RoleName { get; set; }
        public decimal? RateRh { get; set; }
    }

    public class ObjectRightNotAccepted
    {
        public int CRightId { get; set; }
        public int CustId { get; set; }
        public int ObjId { get; set; }
        public string ObjName { get; set; }
        public string GenreName { get; set; }
        public string Duration { get; set; }
        public string RoleName { get; set; }
        public string SpecName { get; set; }
        public decimal Rate { get; set; }
        public string Performer { get; set; }
        public string WorkCommentRH { get; set; }
        public DateTime? WorkDateRH { get; set; }
        public int? WorkTypeRH { get; set; }
    }

    public class ViewCustomer
    {
        public int custId { get; set; }
        public int custType { get; set; }
        public string name { get; set; }
        public int isClient { get; set; }
        public int isRHolder { get; set; }
        public int isPartner { get; set; }
        public string Community_Name { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string Country { get; set; }
    }

    public class ContainerForObjectRihgt
    {
        public ObjectRight objectRight { get; set; }
        public IList<ViewCustomer> rhList { get; set; }
    }
}
