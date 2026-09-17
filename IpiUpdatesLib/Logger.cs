using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IpiUpdatesLib
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
            //Console.WriteLine(line);
            File.AppendAllText(logFullName, $"{line}{Environment.NewLine}");
        }

        public static string GetCurrentFolder()
        {
            return currentFolder;
        }
    }
}
