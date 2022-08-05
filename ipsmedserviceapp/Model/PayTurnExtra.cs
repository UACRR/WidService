using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PayTurnExtra
    {
        public int Turnid { get; set; }
        public DateTime Datework { get; set; }
        public int? Custid { get; set; }
        public int? Payturntype { get; set; }
        public int? CmCustId { get; set; }
        public string BalsDebet { get; set; }
        public string BalsCredit { get; set; }
        public int? CategoryCode { get; set; }
        public int? Objid { get; set; }
    }
}
