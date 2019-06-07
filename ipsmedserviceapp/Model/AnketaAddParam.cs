using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaAddParam
    {
        public int ParamCode { get; set; }
        public string LangCode { get; set; }
        public string ParamName { get; set; }
        public int? CustId { get; set; }
        public string ParamValue { get; set; }

        public virtual Customer Cust { get; set; }
    }
}
