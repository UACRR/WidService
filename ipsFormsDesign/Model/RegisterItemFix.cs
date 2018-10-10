using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterItemFix : IRegisterItemFix
    {
        public int RegId { get; set; }
        public int RegItemId { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }

        public RegisterItem RegI { get; set; }
    }
}

