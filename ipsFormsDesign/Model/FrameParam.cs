using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FrameParam : IFrameParam
    {
        public int SeekCode { get; set; }
        public int? FrameCode { get; set; }
        public string SeekCodeName { get; set; }
        public string SeekName { get; set; }
        public string SeekClm { get; set; }
        public string SeekTbl { get; set; }
        public string SeekString { get; set; }
        public string SeekComment { get; set; }
        public string SeekOut { get; set; }

        public virtual FrameTask FrameCodeNavigation { get; set; }
    }
}

