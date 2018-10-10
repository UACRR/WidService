using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterItemFix
    {
        public int RegId { get; set; }
        public int RegItemId { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }

        public RegisterItem RegI { get; set; }
    }
}
