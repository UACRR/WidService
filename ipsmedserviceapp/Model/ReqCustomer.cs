using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ReqCustomer
    {
        public ReqCustomer()
        {
            Request = new HashSet<Request>();
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
        public virtual ICollection<Request> Request { get; set; }
    }
}
