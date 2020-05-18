using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FrameTask : IFrameTask
    {
        public FrameTask()
        {
            FrameParam = new ObservableListSource<FrameParam>();
        }

        public int TaskCode { get; set; }
        public int FrameCode { get; set; }
        public string FrameName { get; set; }
        public string Comment { get; set; }
        public string FrameShort { get; set; }
        public string FrameExtra { get; set; }

        public virtual PermitTask TaskCodeNavigation { get; set; }
        public virtual ObservableListSource<FrameParam> FrameParam { get; set; }
    }
}

