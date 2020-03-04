using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PermitTask : IPermitTask
    {
        public PermitTask()
        {
            FrameTask = new ObservableListSource<FrameTask>();
            PermitRoleTask = new ObservableListSource<PermitRoleTask>();
            PermitTaskTr = new ObservableListSource<PermitTaskTr>();
        }

        public int CodeI { get; set; }
        public string CodeName { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ObservableListSource<FrameTask> FrameTask { get; set; }
        public virtual ObservableListSource<PermitRoleTask> PermitRoleTask { get; set; }
        public virtual ObservableListSource<PermitTaskTr> PermitTaskTr { get; set; }
    }
}

