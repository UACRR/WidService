using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SystemMessage : ISystemMessage
    {
        public int Id { get; set; }
        public DateTime? Modifydate { get; set; }
        public string NameMain { get; set; }
        public string Name { get; set; }
        public int? KeyObj { get; set; }
        public string Text { get; set; }
        public string Sysname { get; set; }
        public int? CustId { get; set; }
    }
}

