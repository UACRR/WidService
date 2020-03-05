using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FrameTask
    {
        public FrameTask()
        {
            FrameParam = new HashSet<FrameParam>();
        }

        public int TaskCode { get; set; }
        public int FrameCode { get; set; }
        public string FrameName { get; set; }
        public string Comment { get; set; }

        public virtual PermitTask TaskCodeNavigation { get; set; }
        public virtual ICollection<FrameParam> FrameParam { get; set; }
    }
}
