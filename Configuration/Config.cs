using System;
using System.Collections.Generic;
using System.Text;
using Configuration.SettingsModel;

namespace Configuration
{
    public class Config
    {
        public ApplicationWebApiSettings ApplicationWebApiSettings { get; internal set; }
        public PermitWebApiSettings PermitWebApiSettings { get; internal set; }
        public ReportsConnectionSettings ReportsConnectionSettings { get; internal set; }
    }
}
