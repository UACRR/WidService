using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib
{
    [Table("RpnSettings")]
    public class RpnSettings
    {
        [Column(TypeName = "int")] [Key]     public int     Id                  { get; set; }
        [Column(TypeName = "varchar(1024)")] public string  FtpUrl              { get; set; }
        [Column(TypeName = "int")]           public int     FtpPort             { get; set; }
        [Column(TypeName = "varchar(64)")]   public string  FtpLogin            { get; set; }
        [Column(TypeName = "varchar(64)")]   public string  FtpPassword         { get; set; }
        [Column(TypeName = "bit")]           public bool    FtpUseSsl           { get; set; }
        [Column(TypeName = "bit")]           public bool    FtpUseSftp          { get; set; }
        [Column(TypeName = "varchar(1024)")] public string  FtpDumpPath         { get; set; }
        [Column(TypeName = "varchar(1024)")] public string  FtpUpdatesPath      { get; set; }
        [Column(TypeName = "varchar(1024)")] public string  WorkFilesRootPath   { get; set; }
    }
}

