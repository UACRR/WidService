using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    public class ExceptionMember
    {
        [Pk]
        public int Id { get; set; }
        [ImportCurrent]
        public DateTime? DateBegin { get; set; }
        [ImportCurrent]
        public DateTime? DateEnd { get; set; }
        [Fk("ExceptionSet")]
        public int? SetCode { get; set; }
        public int? RHolderType { get; set; }
        public string MemberName { get; set; }
        public string NameForSeek { get; set; }
        public string InterCode { get; set; }
        public int? ExcType { get; set; }
        public int? CustId { get; set; }
        public string Comment { get; set; }
        public string IPInr { get; set; }
        [ImportCurrent]
        public DateTime? DateCreated { get; set; }
        public bool ForPer { get; set; }
        public bool ForMec { get; set; }
    }
}
