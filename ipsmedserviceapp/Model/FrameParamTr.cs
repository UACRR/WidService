using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FrameParamTr
    {
        public int SeekCode { get; set; }
        public string Lang { get; set; }
        public string SeekName { get; set; }

        public virtual FrameParam SeekCodeNavigation { get; set; }
    }
}
