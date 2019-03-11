using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class DictionaryService
    {
        private ApiConnector _webApi = new ApiConnector();
        private readonly string _prefix = "dictionary/";

        // CopyRightKind BEGIN ********************
        public CopyrightKind GetCopyrightKind( int id )
        {
            string url = string.Concat( _prefix, "extra/copyrightkind");
            return _webApi.GetItemById<CopyrightKind>(url, id.ToString());
        }

        public CopyrightKind CreateCopyrightKind( CopyrightKind sors )
        {
            string url = string.Concat(_prefix, "extra/copyrightkind");
            return _webApi.NewItemWithResult(url, sors);
        }

        public CopyrightKind UpdateCopyrightKind(CopyrightKind sors)
        {
            string url = string.Concat(_prefix, "extra/copyrightkind");
            return _webApi.UpdateItemWithResult(url, sors.CodeI.ToString(), sors);
        }

        public bool DeleteCopyrightKind(int id)
        {
            string url = string.Concat(_prefix, "extra/copyrightkind");
            return _webApi.DeleteItem(url, id.ToString());
        }

    }
}
