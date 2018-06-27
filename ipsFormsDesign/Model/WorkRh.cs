using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class WorkRh : IWorkRh
    {
        public int WorkId { get; set; }
        public int? LicAutorId { get; set; }
        public int? CRightId { get; set; }
        public int? WorkTypeRh { get; set; }
        public string WorkCommentRh { get; set; }
        public DateTime? WorkDateRh { get; set; }
        public int? WorkTypeCl { get; set; }
        public DateTime? WorkDateCl { get; set; }
        public string WorkCoommentCl { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }

        public CopyRight CRight { get; set; }
        public LicAuthorBr LicAutor { get; set; }
        public WorkType WorkTypeClNavigation { get; set; }
        public WorkType WorkTypeRhNavigation { get; set; }
    }
}

