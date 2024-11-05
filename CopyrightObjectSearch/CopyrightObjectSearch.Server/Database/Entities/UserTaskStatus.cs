
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CopyrightObjectSearch.Server
{
    public class UserTaskStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] public          int    Id          { get; set; }
        [Column(TypeName = "varchar(32)")]                public required string Code        { get; set; }
        [Column(TypeName = "nvarchar(256)")]              public required string Description { get; set; }
    }
}
