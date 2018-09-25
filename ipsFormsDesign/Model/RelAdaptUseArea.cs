using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelAdaptUseArea : IRelAdaptUseArea
    {
        public int reqId { get; set; }
        public int useAreaTypeCode { get; set; }

        public RequestAdapt req { get; set; }
        public UseAreaType useAreaTypeCodeNavigation { get; set; }
    }
}

