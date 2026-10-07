using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib
{
    [Table("RpnJobTaskSteps")]
    public class RpnJobTaskStep
    {
        [Column(TypeName = "int")] [Key]     public int         Id                      { get; set; }
        [Column(TypeName = "int")]           public int         SeqNr                   { get; set; }
        [Column(TypeName = "int")]           public int         RpnJobTaskId            { get; set; }
        [Column(TypeName = "int")]           public int         RpnJobTaskStepTypeId    { get; set; }
        [Column(TypeName = "varchar(1024)")] public string      FileName                { get; set; }
        [Column(TypeName = "datetime")]      public DateTime    CreatedAt               { get; set; }
        [Column(TypeName = "datetime")]      public DateTime?   StartedAt               { get; set; }
        [Column(TypeName = "datetime")]      public DateTime?   EndedAt                 { get; set; }

        public RpnJobTask         RpnJobTask         { get; set; }
        public RpnJobTaskStepType RpnJobTaskStepType { get; set; }

    }
}


