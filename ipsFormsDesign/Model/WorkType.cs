using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class WorkType : IWorkType
    {
        public WorkType()
        {
            WorkRhWorkTypeClNavigation = new ObservableListSource<WorkRh>();
            WorkRhWorkTypeRhNavigation = new ObservableListSource<WorkRh>();
            WorkTypeTr = new ObservableListSource<WorkTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<WorkRh> WorkRhWorkTypeClNavigation { get; set; }
        public virtual ObservableListSource<WorkRh> WorkRhWorkTypeRhNavigation { get; set; }
        public virtual ObservableListSource<WorkTypeTr> WorkTypeTr { get; set; }
    }
}

