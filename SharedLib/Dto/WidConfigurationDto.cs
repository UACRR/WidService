using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Dto
{
    public class WidConfigurationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FtpUrl { get; set; }
        public string FtpLogin { get; set; }
        public string FtpPassword { get; set; }
        public string FtpWidDumpPath { get; set; }
        public string FtpWidUpdatesPath { get; set; }
        public string LocalFilesRootPath { get; set; }
        public string LocalWidDbConnectionString { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
