using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib
{
    [Table("RpnJobTasks")]
    public class RpnJobTask
    {
        [Column(TypeName = "int")] [Key] public int         Id               { get; set; }
        [Column(TypeName = "int")]       public int         SeqNr            { get; set; }
        [Column(TypeName = "int")]       public int         RpnJobId         { get; set; }
        [Column(TypeName = "int")]       public int         RpnJobTaskTypeId { get; set; }
        [Column(TypeName = "datetime")]  public DateTime    CreatedAt        { get; set; }
        [Column(TypeName = "datetime")]  public DateTime?   StartedAt        { get; set; }
        [Column(TypeName = "datetime")]  public DateTime?   EndedAt          { get; set; }

        public RpnJob                       RpnJob          { get; set; }
        public ICollection<RpnJobTaskStep>  RpnJobTaskSteps { get; set; }

    }
}


