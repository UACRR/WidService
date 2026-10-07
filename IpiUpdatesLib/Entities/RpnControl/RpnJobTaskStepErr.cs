using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib
{
    [Table("RpnJobTaskStepErrs")]
    public class RpnJobTaskStepErr
    {
        [Column(TypeName = "int")] [Key]     public int         Id                      { get; set; }
        [Column(TypeName = "int")]           public int         RpnJobTaskStepId        { get; set; } //0 - PannerError
        [Column(TypeName = "varchar(1024)")] public string      ErrMsg                  { get; set; }
        [Column(TypeName = "datetime")]      public DateTime    CreatedAt               { get; set; }

    }
}


