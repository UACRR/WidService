using System;

namespace ipsFormsDesign.ViewModels.Other
{
    public class PublisherAndSubpublisherView
    {
        public int CustIdPub { get; set; }
        public int CustIdSub { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? CreateDate { get; set; }
        public string PubName { get; set; }
        public string SubName { get; set; }
    }
}
