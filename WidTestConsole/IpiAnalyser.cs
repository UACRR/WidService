using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WidTestConsole
{
    public class IpiAnalyserOld
    {
        public static void GetRecordTypes()
        {
            var recNames = new HashSet<string>();
            var files = Directory.GetFiles(@"D:\UACRR\WID\IPI\FtpMirror\IPI\download", "*.IPI");
            foreach(var file in files)
            {
                Console.WriteLine(file);
                using(var sr = new StreamReader(file))
                {
                    var line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        var recName = line.Substring(0, 3);
                        if(!recNames.Contains(recName))
                        {
                            recNames.Add(recName);
                        }
                    }
                    sr.Close();
                }
            }
            foreach(var recName in recNames)
            {
                Console.WriteLine(recName);
            }
        }

        public static void AddGrId()
        {
            var files = Directory.GetFiles(@"D:\UACRR\WID\IPI\Entities", "*.cs");
            foreach(var file in files)
            {
                var targetPath = Path.Combine(Path.GetDirectoryName(file), "Result");
                var name = Path.GetFileName(file);
                var txt = File.ReadAllText(file);
                txt = txt.Replace("[Column(TypeName = \"int\")] public int UpdFileId { get; set; }",
                    "[Column(TypeName = \"int\")] public int UpdFileId { get; set; }\r\n        [Column(TypeName = \"varchar(5)\")] public string GrId { get; set; }");
                File.WriteAllText(Path.Combine(targetPath, name), txt);
            }
        }
        public static void GetTranTypes()
        {
            var recNames = new HashSet<string>();
            var files = Directory.GetFiles(@"D:\UACRR\WID\IPI\FtpMirror\IPI\download", "*.IPI");
            foreach (var file in files)
            {
                Console.WriteLine(file);
                using (var sr = new StreamReader(file))
                {
                    var line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        var recName = line.Substring(0, 3);
                        if(recName == "GRH")
                        {
                            var detailName = line.Substring(3, 3);
                            if (!recNames.Contains(detailName))
                            {
                                recNames.Add(detailName);
                            }
                        }
                        
                    }
                    sr.Close();
                }
            }
            foreach (var recName in recNames)
            {
                Console.WriteLine(recName);
            }
        }

        private static IDisposable StreamReader(string file)
        {
            throw new NotImplementedException();
        }
    }
}
