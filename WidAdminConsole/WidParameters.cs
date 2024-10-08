using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidAdminConsole
{
    public class WidParameters
    {
        [ReadOnly(true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FtpUrl { get; set; }
        public string FtpLogin { get; set; }
        public string FtpPassword { get; set; }
        public string FtpWidDumpPath { get; set; }
        public string FtpWidUpdatesPath { get; set; }
        public string LocalFilesRootPath { get; set; }
        public string LocalWidDbConnectionString { get; set; }
        [ReadOnly(true)]
        public DateTime? CreatedAt { get; set; }
        [ReadOnly(true)]
        public DateTime? UpdatedAt { get; set; }
    }
}
