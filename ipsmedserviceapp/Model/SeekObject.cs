using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SeekObject
    {
        public int Id { get; set; }
        public int? CodeI { get; set; }
        public int? ObjId { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual SeekType CodeINavigation { get; set; }
        public virtual ObjectRight Obj { get; set; }
    }
}
