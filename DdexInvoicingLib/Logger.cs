using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InvoicingLib
{
    public static class Logger
    {
        public static BackgroundWorker bw;
        private static StreamWriter sw;

        public static ConcurrentQueue<string> messages = new ConcurrentQueue<string>();

        public static void OpenFile(object obj)
        {
            string fileBaseName = obj.GetType().Name;
            fileBaseName = fileBaseName.Substring(0, fileBaseName.Length - "Runner".Length);
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Directory.CreateDirectory($"{path}\\log");
            string fileFullName = $"{path}\\log\\{fileBaseName}_{DateTime.Now.ToString("yyyy-MM-dd-HHmmss")}.log";
            sw = new System.IO.StreamWriter(fileFullName);
        }

        public static void CloseFile()
        {
            if (sw != null)
            {
                sw.Close();
            }
        }

        public static void WriteLine(string text)
        {
            text = $"{DateTime.Now.ToString()}: {text}";
            //Console.WriteLine(text);
            if (sw != null)
            {
                sw.WriteLine(text); sw.Flush();
            }

            messages.Enqueue($"{text}\r\n");
            if(bw != null)
                bw.ReportProgress(0);
        }

        public static void Write(string text)
        {
            //Console.Write(text);
            if (sw != null)
            {
                sw.WriteLine(text); sw.Flush();
            }

            messages.Enqueue($"{text}");
            if (bw != null)
                bw.ReportProgress(0);
        }
    }
}
