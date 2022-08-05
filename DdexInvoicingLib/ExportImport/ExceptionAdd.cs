using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    public class ExceptionAdd
    {
        [Pk]
        public int Id { get; set; }
        [Fk("ExceptionMember")]
        public int? ExcId { get; set; }
        public int? CustId { get; set; }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public string NameForSeek { get; set; }
        public string IPInr { get; set; }
        [ImportCurrent]
        public DateTime? DateCreated { get; set; }
    }
}
