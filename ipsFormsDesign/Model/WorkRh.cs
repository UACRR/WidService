using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class WorkRH : IWorkRH
    {
        public int cRightId { get; set; }
        public int? workTypeRH { get; set; }
        public string workCommentRH { get; set; }
        public DateTime? workDateRH { get; set; }
        public int? workTypeCl { get; set; }
        public DateTime? workDateCl { get; set; }
        public string workCoommentCl { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }

        public CopyRight cRight { get; set; }
        public WorkType workTypeClNavigation { get; set; }
        public WorkType workTypeRHNavigation { get; set; }
    }
}

