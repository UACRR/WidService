using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CustCmRight
    {
        public int CustId { get; set; }
        public int CRkindCode { get; set; }
        public int CmCustId { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }

        public virtual TermsOfService C { get; set; }
        public virtual Community CmCust { get; set; }
    }
}
