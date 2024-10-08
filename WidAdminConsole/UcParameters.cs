using SharedLib.Dto;
using SharedLib.Requests;
using SharedLib.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidAdminConsole
{
    public partial class UcParameters : UserControl
    {
        private WidParameters _widParameters;
        private WidParameters _oldWidParameters;
        public UcParameters()
        {
            InitializeComponent();
        }
        private async Task GetWidParameters()
        {
            HttpClient client = new HttpClient();
            WidConfigurationRsp widConfigurationRsp = null;
            HttpResponseMessage response = await client.GetAsync(Program.GetUrl("widconfiguration"));
            if (response.IsSuccessStatusCode)
            {
                widConfigurationRsp = await response.Content.ReadAsAsync<WidConfigurationRsp>();
            }
            _widParameters = new WidParameters {
                Id = widConfigurationRsp.WidConfiguration.Id,
                Name = widConfigurationRsp.WidConfiguration.Name,
                FtpUrl = widConfigurationRsp.WidConfiguration.FtpUrl,
                FtpLogin = widConfigurationRsp.WidConfiguration.FtpLogin,
                FtpPassword = widConfigurationRsp.WidConfiguration.FtpPassword,
                FtpWidDumpPath = widConfigurationRsp.WidConfiguration.FtpWidDumpPath,
                FtpWidUpdatesPath = widConfigurationRsp.WidConfiguration.FtpWidUpdatesPath,
                LocalFilesRootPath = widConfigurationRsp.WidConfiguration.LocalFilesRootPath,
                LocalWidDbConnectionString = widConfigurationRsp.WidConfiguration.LocalWidDbConnectionString,
                CreatedAt = widConfigurationRsp.WidConfiguration.CreatedAt,
                UpdatedAt = widConfigurationRsp.WidConfiguration.UpdatedAt,
            };
        }

        private async Task PostWidParameters()
        {
            HttpClient client = new HttpClient();
            var rq = new WidConfigurationRq
            {
                WidConfiguration = new WidConfigurationDto
                {
                    Id = _widParameters.Id,
                    Name = _widParameters.Name,
                    FtpUrl = _widParameters.FtpUrl,
                    FtpLogin = _widParameters.FtpLogin,
                    FtpPassword = _widParameters.FtpPassword,
                    FtpWidDumpPath = _widParameters.FtpWidDumpPath,
                    FtpWidUpdatesPath = _widParameters.FtpWidUpdatesPath,
                    LocalFilesRootPath = _widParameters.LocalFilesRootPath,
                    LocalWidDbConnectionString = _widParameters.LocalWidDbConnectionString,
                    CreatedAt = _widParameters.CreatedAt,
                    UpdatedAt = _widParameters.UpdatedAt,
                },
            };
            var result = false;
            HttpResponseMessage response = await client.PostAsJsonAsync(Program.GetUrl("widconfiguration"), rq);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<bool>();
            }
            if(!result)
            {
                _widParameters = null;
            }
        }

        private void UcParameters_Load(object sender, EventArgs e)
        {
            try
            {
                var task = Task.Run(async () => await GetWidParameters());
                task.Wait();
                pgParameters.SelectedObject = _widParameters;
                _oldWidParameters = new WidParameters
                {
                    Id = _widParameters.Id,
                    Name = _widParameters.Name,
                    FtpUrl = _widParameters.FtpUrl,
                    FtpLogin = _widParameters.FtpLogin,
                    FtpPassword = _widParameters.FtpPassword,
                    FtpWidDumpPath = _widParameters.FtpWidDumpPath,
                    FtpWidUpdatesPath = _widParameters.FtpWidUpdatesPath,
                    LocalFilesRootPath = _widParameters.LocalFilesRootPath,
                    LocalWidDbConnectionString = _widParameters.LocalWidDbConnectionString,
                    CreatedAt = _widParameters.CreatedAt,
                    UpdatedAt = _widParameters.UpdatedAt,
                };            
            }
            catch(Exception)
            {
                pgParameters.SelectedObject = _widParameters;
                _oldWidParameters = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var task = Task.Run(async () => await PostWidParameters());
            task.Wait();
            if(_widParameters == null)
            {
                MessageBox.Show("Зміна параметрів в даний час не можлива!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _widParameters = _oldWidParameters;
            }
            pgParameters.SelectedObject = _widParameters;
        }
    }
}
