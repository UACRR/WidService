using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidAdminLib.Entities
{
    [Table("WidConfigurations")]
    public class WidConfigurationEntity
    {
        [Column(TypeName = "int")] [Key] public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")] public string Name { get; set; }
        [Column(TypeName = "varchar(1024)")] public string WidFtpUrl { get; set; }
        [Column(TypeName = "varchar(64)")] public string WidFtpLogin { get; set; }
        [Column(TypeName = "varchar(64)")] public string WidFtpPassword { get; set; }
        [Column(TypeName = "varchar(1024)")] public string WidFtpDumpPath { get; set; }
        [Column(TypeName = "varchar(1024)")] public string WidFtpUpdatesPath { get; set; }
        [Column(TypeName = "varchar(1024)")] public string WidWorkFilesRootPath { get; set; }
        [Column(TypeName = "varchar(1024)")] public string IpiFtpUrl { get; set; }
        [Column(TypeName = "varchar(64)")] public string IpiFtpLogin { get; set; }
        [Column(TypeName = "varchar(64)")] public string IpiFtpPassword { get; set; }
        [Column(TypeName = "varchar(1024)")] public string IpiFtpDumpPath { get; set; }
        [Column(TypeName = "varchar(1024)")] public string IpiFtpUpdatesPath { get; set; }
        [Column(TypeName = "varchar(1024)")] public string IpiWorkFilesRootPath { get; set; }
        [Column(TypeName = "datetime")] public DateTime? CreatedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? UpdatedAt { get; set; }

        public ICollection<WidTaskEntity> WidTasks { get; set; }
    }
}
