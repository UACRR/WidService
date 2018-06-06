using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class ObjectRightService
    {
        private ApiConnector _webApi = new ApiConnector();

        public ObjectRightDictionaries GetDictionary()
        {
            return _webApi.GetItemById<ObjectRightDictionaries>("dictionary", "objectright"); ;
        }
    }
}
