
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CopyrightObjectSearch.Server
{
    public class Partner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] public          int    Id          { get; set; }
        [Column(TypeName = "varchar(32)")]                public            string? Code        { get; set; }
        [Column(TypeName = "nvarchar(256)")]              public            string? Description { get; set; }

        public ICollection<PartnerWorkSource>? PartnerWorkSources { get; set; } 
        public ICollection<PartnerToSourceType>? PartnerToSourceType { get; set; }  
    }
}
