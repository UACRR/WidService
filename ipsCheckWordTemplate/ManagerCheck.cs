using ipsCheckWordTemplate.Model;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ipsCheckWordTemplate
{
    public class ManagerCheck
    {
        private List<string> _validTag = new List<string>();
        private List<string> _importTag = new List<string>();

        private static Application app;
        private Microsoft.Office.Interop.Word.Document innerDoc;

        public bool IsInit { get => _importTag.Count > 0; }
        internal Application StartWordApp()
        {
            if (app == null)
                app = new Application();

            return app;
        }


        void StopWordApp()
        {
            if (app != null)
            {
                app.Quit();
                Marshal.ReleaseComObject(app);
                app = null;
            }
        }
        public void OpenWord(string FileName)
        {
            _importTag = new List<string>();
            app = StartWordApp();
            innerDoc = app.Documents.Open(FileName);
            var list = innerDoc.ContentControls;

            foreach (ContentControl item in list)
            {
                item.LockContentControl = false;
                item.Temporary = true;
                string title = item.Title.Trim();

                _importTag.Add(title);
            }

            innerDoc.Close(false);
            StopWordApp();
        }

        public void OpenValidTag(string FileName)
        {
            _validTag = new List<string>();
            using (var file = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            using (var sr = new StreamReader(file))
            {
                string getLine = string.Empty;
                while ((getLine = sr.ReadLine()) != null )
                {
                    if (getLine.Trim().Length == 0)
                        break;

                    _validTag.Add(getLine);
                }
            }

            _validTag.Sort();
        }

        public List<TagInfo> CheckTag()
        {

            List<TagInfo> retList = new List<TagInfo>();
            Regex check = new Regex("[а-яА-Я]");

            _importTag.ForEach(item => {

                TagInfo newItem = new TagInfo { name = item };
                if (check.IsMatch(item))
                    newItem.isCyrillic = true;

                if (_validTag.BinarySearch(item) < 0)
                    newItem.isNotInList = true;

                retList.Add( newItem );
            });


            return retList;
        }
    }
}
