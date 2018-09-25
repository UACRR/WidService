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

        public TermsOfService C { get; set; }
        public Community CmCust { get; set; }
    }
}
