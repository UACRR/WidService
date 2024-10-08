using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WidAdminLib
{
    public class Logger
    {
        private static string rootPath;
        private static string subFolder;
        private static string currentFolder;
        private static string logFullName;

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
            Init();
            //Console.WriteLine(line);
            File.AppendAllText(logFullName, $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff")}    {line}{Environment.NewLine}");
        }

        public static string GetCurrentFolder()
        {
            return currentFolder;
        }

        private static void Init()
        {
            if(rootPath != null)
            {
                return;
            }
            var exeFileFullName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            rootPath = System.IO.Path.GetDirectoryName(exeFileFullName);
            SetRootPath(Path.Combine(rootPath, "Log"));
            SetSubFolder("WidAdminLib");
            WriteLine($"STARTING SERVICE");
        }
    }
}
