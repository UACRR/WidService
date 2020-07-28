using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ProcessManagement : IProcessManagement
    {
        public int ProcessId { get; set; }
        public int? ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public string Comment { get; set; }
        public int? Status { get; set; }
        public DateTime? DateStop { get; set; }
        public string UserLogin { get; set; }
        public DateTime? DateModify { get; set; }
        public int? StatusAvto { get; set; }
        public DateTime? DateStopAvto { get; set; }
        public DateTime? DateStopBegin { get; set; }
    }
}

