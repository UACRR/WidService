using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Settings
{
    public partial class SettingsWindow : Telerik.WinControls.UI.RadForm
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private string ConfigPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "workplace.config");
        

        #region METHODS

        private void CheckConfigFileExist()
        {
            if(!File.Exists(ConfigPath))
            {
                using (var file = File.Create(AppDomain.CurrentDomain.BaseDirectory))
                {
                    
                    Configuration config = GetConfiguration(); 
                    config.AppSettings.Settings.Add("", "");

                    file.Close();
                }
            }
        }

        private Configuration GetConfiguration()
        {
            string configName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "workplace.config");
            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
            configFile.ExeConfigFilename = configName;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);

            return config;
        }

        private string GetPermitUri()
        {
            string configName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "workplace.config");
            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
            configFile.ExeConfigFilename = configName;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);

            string uri = config.AppSettings.Settings["SmRoPermitApiBaseUri"].Value;
            return uri;
        }

        #endregion

        #region EVENTS HANDLERS



        #endregion

        private void tbRepPwVisible_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            txtREP_PW.PasswordChar = tbRepPwVisible.IsChecked ? default(char) : '*';
        }

        private void tbDdexPwVisible_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            txtDDEX_PW.PasswordChar = tbDdexPwVisible.IsChecked ? default(char) : '*';
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {

        }
    }
}
