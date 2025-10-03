using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppleSearch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var ret = LevenshteinDistance.Compute("digital", "digital");

            //DataRefiner.GenerateSpRefineTexts(@"D:\OlegM\Sources\WidService\AppleSearch\Sql\spRefineTextsGenerated.sql");
            //DataRefiner.GenerateRefineTriggers(@"D:\OlegM\Sources\WidService\AppleSearch\Sql\CreateRefineTriggersGenerated.sql");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
