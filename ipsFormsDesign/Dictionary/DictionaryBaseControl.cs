using ipsFormsDesign.Definition;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIConnector;
using ipsmedserviceapp.Model;

namespace ipsFormsDesign.Dictionary
{
    public class DictionaryBaseControl : IFormControl

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