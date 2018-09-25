using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AnketaAddParam : IAnketaAddParam
    {
        public int paramCode { get; set; }
        public string langCode { get; set; }
        public string paramName { get; set; }
        public int? custId { get; set; }
        public string paramValue { get; set; }

        public Customer cust { get; set; }
    }
}

