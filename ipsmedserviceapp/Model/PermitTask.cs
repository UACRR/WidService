using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PermitTask
    {
        public PermitTask()
        {
            FrameTask = new HashSet<FrameTask>();
            PermitRoleTask = new HashSet<PermitRoleTask>();
            PermitTaskTr = new HashSet<PermitTaskTr>();
        }

        public int CodeI { get; set; }
        public string CodeName { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<FrameTask> FrameTask { get; set; }
        public virtual ICollection<PermitRoleTask> PermitRoleTask { get; set; }
        public virtual ICollection<PermitTaskTr> PermitTaskTr { get; set; }
    }
}
