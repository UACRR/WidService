using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public static class AppConfiguration
    {
        private static Config _config;
        public static Config Config
        {
            get
            {
                if (_config == null)
                    CreateConfig();

                return _config;
            }
            private set => _config = value;
        }

        private static void CreateConfig()
        {
            Config = new Config();
        }
    }
}

