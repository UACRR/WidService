using System;
using System.Collections.Generic;
using System.Text;
using WidAdminLib;
using WidServiceLib;

namespace WidTestConsole
{
    public static class WidReplicationTests
    {
        public static void RunFileDownload()
        {
            var service = new WidReplicationServiceDummy();
            service.ActionStatusChanged += Service_ActionStatusChanged;
            service.RunWidFileDownload("", "qwerty");
        }

        private static void Service_ActionStatusChanged(object sender, WidReplicationServiceLib.IWidReplicationService.ActionStatusChangedArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
