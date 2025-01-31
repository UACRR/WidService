
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CopyrightObjectSearch.Server
{
    public class PartnerToSourceType
    {
        public int PartnerId { get; set; }
        public int SourceTypeId { get; set; }
        public Partner? Partner { get; set; }
        public PartnerWorkSourceType? SourceType { get; set; }

        public ICollection<PartnerWorkSourceType>? PartnerWorkSourceTypes { get; set; }      
    }
}
