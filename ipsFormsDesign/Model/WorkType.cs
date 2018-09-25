using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class WorkType : IWorkType
    {
        public WorkType()
        {
            WorkRHworkTypeClNavigation = new ObservableListSource<WorkRH>();
            WorkRHworkTypeRHNavigation = new ObservableListSource<WorkRH>();
            WorkTypeTr = new ObservableListSource<WorkTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<WorkRH> WorkRHworkTypeClNavigation { get; set; }
        public ObservableListSource<WorkRH> WorkRHworkTypeRHNavigation { get; set; }
        public ObservableListSource<WorkTypeTr> WorkTypeTr { get; set; }
    }
}

