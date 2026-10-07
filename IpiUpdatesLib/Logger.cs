using Microsoft.VisualBasic;
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

        private static int _stepId;

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
            lock (_lock)
            {
                try { File.AppendAllText(logFullName, $"{line}{Environment.NewLine}" ); } catch { }
            }
        }

        public static string GetCurrentFolder()
        {
            return currentFolder;
        }

        public static void SetStepId(int stepId)
        {
            lock (_lock) {_stepId = stepId; };
        }

        public static void WriteErr(string txt)
        {
            lock (_lock)
            {
                try { File.AppendAllText(logFullName, $"{txt}{Environment.NewLine}" ); } catch { }

                try
                {
                    var dbc = new IpiUpdatesDbContext();
                    var err = new RpnJobTaskStepErr {RpnJobTaskStepId = _stepId, ErrMsg = txt, CreatedAt = DateTime.Now};
                    dbc.RpnJobTaskStepErrs.Add(err);
                    dbc.SaveChanges();
                }
                catch { }
            }
        }
    }
}
