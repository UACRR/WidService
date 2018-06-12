using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Services
{
    public class WordEngine
    {
        public string TempDirectory { get;  }
        public WordEngine( string tempDirectory )
        {
            TempDirectory = tempDirectory;
        }

        public void processRightHolder( string pathTemplate, RightHolder rightHolder )
        {

        }
    }
}
