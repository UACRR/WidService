using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    static public class Logger
    {
        private static string _logFileFullName;
        public static void Init()
        {
            var exePath = Path.GetDirectoryName(Application.ExecutablePath);
            var logPath = Path.Combine(exePath, "Log");
            Directory.CreateDirectory(logPath);
            var ts = DateTime.Now.ToString("yyyyMMddhhmmss");
            var logFileName = $"RadioStationReports_{ts}.log";
            _logFileFullName = Path.Combine(logPath, logFileName);
            File.WriteAllText(_logFileFullName, "Logging started");
        }

        public static void WriteLine(string msg)
        {
            File.AppendAllText(_logFileFullName, $"{msg}\r\n");
        }
    }
}
