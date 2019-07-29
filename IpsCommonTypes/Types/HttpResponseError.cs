using System;
using System.Collections.Generic;
using System.Text;

namespace IpsCommonTypes.Types
{
    public class HttpResponseError
    {
        public int? StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public string MethodType { get; set; }
    }
}
