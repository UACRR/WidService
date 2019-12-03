using System;
using System.Collections.Generic;
using System.Xml;

namespace LanguageLibrary.Kernel
{
    internal class LanguageLibraryHelper
    {
        private const string LanguageInfoPath = @"Languages\LanguagesInfo.xml";

        private readonly XmlDocument _xmlDocument;
        
        public LanguageLibraryHelper()
        {
            _xmlDocument = new XmlDocument();
        }

        internal void LoadLanguageInfo()
        {
            _xmlDocument.Load(LanguageInfoPath);
            
        }


        internal void CreateLanguageTemplate()
        {

        }
    }
}
