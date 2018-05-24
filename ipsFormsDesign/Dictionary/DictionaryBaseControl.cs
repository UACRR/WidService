using ipsFormsDesign.Definition;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIConnector;

namespace ipsFormsDesign.Dictionary
{
    public class DictionaryBaseControl 

    {
        private ApiConnector connector = new ApiConnector("http://localhost:54867/");

        public DictionaryBaseControl()
        {
        }


        public IList<object> GetDefaultDicData(string item)
        {
            return null;
        }
    }
}