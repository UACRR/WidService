using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IpiReplSvc
{
    public class Logger
    {
        private static string rootPath;
        private static string subFolder;
        private static string currentFolder;
        private static string logFullName;

        private static object _lock = new object();

        public static void SetRootPath(string path)
        {
            rootPath = path;
        }

        public static void SetSubFolder(string name)
        {
            subFolder = name;
            currentFolder = Path.Combine(rootPath, subFolder);
            Directory.CreateDirectory(currentFolder);
            logFullName = Path.Combine(currentFolder, "Log.log");
            File.Delete(logFullName);
        }

        public static void WriteLine(string line)
        {
            lock(_lock)
            {
                //Console.WriteLine(line);
                File.AppendAllText(logFullName, $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff")}    {line}{Environment.NewLine}");
            }
        }
    }
}
