using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.Json;
using Configuration.SettingsModel;

namespace Configuration
{
    public static class AppConfiguration
    {
        private const string ConfigName = "applicationSettings.json";

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
            string environmentConfigName = Path.Combine(Environment.CurrentDirectory, ConfigName);
            environmentConfigName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigName);

            System.Configuration.Configuration cfg = ConfigurationManager.OpenExeConfiguration(environmentConfigName);
            ConfigurationSection section = cfg.GetSection("CurrentEnvironment");
            

            object environmentJson = environmentConfigName;

            var environment = GetSettingFromJsonConfig<CurrentEnvironment>(environmentJson);

            var config = Path.Combine(Environment.CurrentDirectory, environment.ConfigName);

            object json = config;
            
            // read json cfg
            
            Config = new Config
            {
                ApplicationWebApiSettings = GetSettingFromJsonConfig<ApplicationWebApiSettings>(json),
                PermitWebApiSettings = GetSettingFromJsonConfig<PermitWebApiSettings>(json),
                ReportsConnectionSettings = GetSettingFromJsonConfig<ReportsConnectionSettings>(json),
            };
        }

        private static T GetSettingFromJsonConfig<T>(object json) where T : class, new()
        {
            string section = nameof(T);

            return new T();
        }
    }
}

