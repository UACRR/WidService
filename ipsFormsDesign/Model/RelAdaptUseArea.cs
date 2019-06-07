using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelAdaptUseArea : IRelAdaptUseArea
    {
        public int ReqId { get; set; }
        public int UseAreaTypeCode { get; set; }

        public virtual RequestAdapt Req { get; set; }
        public virtual UseAreaType UseAreaTypeCodeNavigation { get; set; }
    }
}

