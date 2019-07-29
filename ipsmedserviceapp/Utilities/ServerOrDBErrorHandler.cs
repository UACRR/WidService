using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using IpsCommonTypes.Types;

namespace ipsmedserviceapp.Utilities
{
    public static class ServerOrDBErrorHandler
    {
        public static async void CreateControllerErrorLog(this MediaServiceContext context, RequestError requestError)
        {
            // save to db new error
        }
    }
}
