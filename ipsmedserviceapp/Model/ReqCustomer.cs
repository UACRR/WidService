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

        public int reqCustId { get; set; }
        public int? custId { get; set; }
        public string name { get; set; }
        public string countryCode { get; set; }
        public string okpo { get; set; }
        public string nickName { get; set; }
        public int? activityCode { get; set; }
        public string comment { get; set; }

        public ActivityType activityCodeNavigation { get; set; }
        public Country countryCodeNavigation { get; set; }
        public Customer cust { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}
