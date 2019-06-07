using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ReqCustomer : IReqCustomer
    {
        public ReqCustomer()
        {
            Request = new ObservableListSource<Request>();
        }

        public int ReqCustId { get; set; }
        public int? CustId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Okpo { get; set; }
        public string NickName { get; set; }
        public int? ActivityCode { get; set; }
        public string Comment { get; set; }

        public virtual ActivityType ActivityCodeNavigation { get; set; }
        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual ObservableListSource<Request> Request { get; set; }
    }
}

