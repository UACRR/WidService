using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FrameParamTr : IFrameParamTr
    {
        public int SeekCode { get; set; }
        public string Lang { get; set; }
        public string SeekName { get; set; }

        public virtual FrameParam SeekCodeNavigation { get; set; }
    }
}

