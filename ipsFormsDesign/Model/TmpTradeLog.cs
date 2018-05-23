using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TmpTradeLog : ITmpTradeLog
    {
        public int Id { get; set; }
        public int? RegId { get; set; }
        public string Value { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}

