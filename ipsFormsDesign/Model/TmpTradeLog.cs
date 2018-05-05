using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TmpTradeLog
    {
        public int Id { get; set; }
        public int? RegId { get; set; }
        public string Value { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
