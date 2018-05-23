using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaAddParam : IAnketaAddParam
    {
        public int ParamCode { get; set; }
        public string LangCode { get; set; }
        public string ParamName { get; set; }
        public int? CustId { get; set; }
        public string ParamValue { get; set; }

        public Customer Cust { get; set; }
    }
}

