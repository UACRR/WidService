using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static WidExport.UcMainFileExchange;

namespace WidExport
{
    public partial class UcMainFileExchange : UserControl
    {
        public class ExchangeFile
        {
            public int SubmFileId { get; set; }
            public int? SubmFileGroupId { get; set; }
            public string SubmFileGroupName { get; set; }
            public string SubmFileName { get; set; }
            public string RespFileName { get; set; }
            public int SubmFileStatus { get; set; }
        }

        public string[] _exchangeFileStatusText =
        {
            "Очікує передачі",
            "Переданий",
            "Відповідь отримана",
            "Відхилений",
            "Передача не завершена",
        };

        private List<ExchangeFile> _exchangeFiles;

        public UcMainFileExchange()
        {
            InitializeComponent();
        }

        private void UcMainFileExchange_Load(object sender, EventArgs e)
        {
            lvFiles.Columns.Add("Група", 100);
            lvFiles.Columns.Add("Файл публікації", 300);
            lvFiles.Columns.Add("Файл відповіді", 300);
            lvFiles.Columns.Add("Статус обміну", 300);
        }
        public void RefreshControls()
        {
            using (var wc = new WaitCursor())

            _exchangeFiles = new List<ExchangeFile>();
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spMainFileExchangeSelect";
                using(var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        _exchangeFiles.Add(new ExchangeFile
                        {
                            SubmFileId = r.GetInt32(0),
                            SubmFileGroupId = r.IsDBNull(1) ? (int?)null :r.GetInt32(1),
                            SubmFileGroupName = r.IsDBNull(2) ? null : r.GetString(2),
                            SubmFileName = r.GetString(3),
                            RespFileName = r.GetString(4),
                            SubmFileStatus = r.GetInt32(5),
                        });
                    }
                }
            });

            lvFiles.Items.Clear();
            _exchangeFiles.ForEach(x =>
            {
                var item = lvFiles.Items.Add(x.SubmFileGroupName == null ? "" : x.SubmFileGroupName);
                item.SubItems.Add(x.SubmFileName);
                item.SubItems.Add(x.RespFileName);
                item.SubItems.Add(_exchangeFileStatusText[x.SubmFileStatus]);
                item.Tag = x;
            });

            RefreshButtons();
        }

        private void RefreshButtons()
        {
            if(lvFiles.SelectedItems.Count == 0)
            {
                btnShowGroup.Enabled  =
                btnDeleteFile.Enabled =
                btnSendToFtp.Enabled  = 
                btnShowSubmFileInFolder.Enabled =
                btnShowRespFileInFolder.Enabled = false;
            }
            else
            {
                btnShowGroup.Enabled = true;

                var exchangeFile = (ExchangeFile)lvFiles.SelectedItems[0].Tag;
                btnDeleteFile.Enabled = exchangeFile.SubmFileStatus == (int)ExchangeFileStatus.Created;
                btnSendToFtp.Enabled = exchangeFile.SubmFileStatus == (int)ExchangeFileStatus.Created ||
                    exchangeFile.SubmFileStatus == (int)ExchangeFileStatus.Uploaded;
                btnShowSubmFileInFolder.Enabled = !string.IsNullOrEmpty(exchangeFile.SubmFileName);
                btnShowRespFileInFolder.Enabled = !string.IsNullOrEmpty(exchangeFile.RespFileName);
            }
        }

        private void btnShowGroup_Click(object sender, EventArgs e)
        {
            var exchangeFile = (ExchangeFile)lvFiles.SelectedItems[0].Tag;
            if(exchangeFile.SubmFileGroupId == null)
            {
                return;
            }
            var form = new FormWidSubmit(WidSubmGroup.FromDb((int)exchangeFile.SubmFileGroupId), null);
            form.Show();
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshButtons();
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 0)
            {
                return;
            }
            var exchangeFile = (ExchangeFile)lvFiles.SelectedItems[0].Tag;

            if(DialogResult.Yes != MessageBox.Show("Видалити файл публікації?", "Файли обміну", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            if(exchangeFile.SubmFileStatus != (int)ExchangeFileStatus.Created)
            {
                MessageBox.Show("Не можна видалити переданий файл", "Файли обміну", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var fileName = "";
            using (var wc = new WaitCursor())
            Helpers.RunSqlSocWidSubmitT(cmd =>
            {
                cmd.CommandTimeout = 60;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Name from SubmFile where Id = @submFileId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@submFileId", exchangeFile.SubmFileId);
                fileName = (string)cmd.ExecuteScalar();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSubmFileClearRecRefs";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@submFileId", exchangeFile.SubmFileId);
                cmd.ExecuteNonQuery();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSubmFileClear";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@submFileId", exchangeFile.SubmFileId);
                cmd.ExecuteNonQuery();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from SubmFile where Id = @submFileId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@submFileId", exchangeFile.SubmFileId);
                cmd.ExecuteNonQuery();
            });

            var folderPath = Path.Combine(ConfigurationManager.AppSettings["FileExchangeRootDir"], "OutFiles");
            File.Delete(Path.Combine(folderPath, fileName));

            RefreshControls();
        }

        private bool UploadFile(ExchangeFile exchangeFile)
        {
            try
            {
                Helpers.RunSqlSocWidSubmitT(async cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spSubmFilePreSend";
                    cmd.Parameters.AddWithValue("@submFileId", exchangeFile.SubmFileId);
                    cmd.ExecuteNonQuery();

                    var appSettings = ConfigurationManager.AppSettings;

                    var targetFile = $"{appSettings["FileExchangeFtpSubmDir"]}/{exchangeFile.SubmFileName}";
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(targetFile);
                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    request.Credentials = new NetworkCredential(appSettings["FileExchangeFtpLogin"], appSettings["FileExchangeFtpPassword"]);

                    var folderPath = Path.Combine(appSettings["FileExchangeRootDir"], "OutFiles");
                    var sourceFile = Path.Combine(folderPath, exchangeFile.SubmFileName);

                    using (FileStream fileStream = File.Open(sourceFile, FileMode.Open, FileAccess.Read))
                    {
                        using (Stream requestStream = request.GetRequestStream())
                        {
                            await fileStream.CopyToAsync(requestStream);
                        }
                    }
                    FtpStatusCode statusCode;
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        statusCode = response.StatusCode;
                    }
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Файли обміну", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        public bool FileUploaded(ExchangeFile exchangeFile)
        {
            var appSettings = ConfigurationManager.AppSettings;

            var targetFile = $"{appSettings["FileExchangeFtpSubmDir"]}/{exchangeFile.SubmFileName}";
            FtpWebRequest fileSizeRequest = (FtpWebRequest)WebRequest.Create($"{targetFile}");
            fileSizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            fileSizeRequest.Credentials = new NetworkCredential(appSettings["FileExchangeFtpLogin"], appSettings["FileExchangeFtpPassword"]);

            try
            {
                FtpWebResponse response = (FtpWebResponse)fileSizeRequest.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private void btnSendToFtp_Click(object sender, EventArgs e)
        {
            if(lvFiles.SelectedItems.Count == 0)
            {
                return;
            }

            if (DialogResult.Yes != MessageBox.Show("Передати файл публікації?", "Файли обміну", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            var exchangeFile = (ExchangeFile)lvFiles.SelectedItems[0].Tag;
            if (
                exchangeFile.SubmFileStatus != (int)ExchangeFileStatus.Created &&
                exchangeFile.SubmFileStatus != (int)ExchangeFileStatus.Uploaded
            )
            {
                MessageBox.Show("Файл вже переданий", "Файли обміну", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Application.OpenForms.Count > 1)
            {
                MessageBox.Show("Закрийте форми, крім головної, і повторіть операцію", "Файли обміну", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                
                var folderPath = Path.Combine(appSettings["FileExchangeRootDir"], "OutFiles");
                var sourceFile = Path.Combine(folderPath, exchangeFile.SubmFileName);

                var wrongLineIdx = FileValidator.Validate(sourceFile);
                if(wrongLineIdx.Count() != 0)
                {
                    MessageBox.Show("Файл містить помилки", "Файли обміну", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if(!FileUploaded(exchangeFile))
                {
                    var fileUploadRes = UploadFile(exchangeFile);
                    if (!fileUploadRes)
                    {
                        return;
                    }

                    exchangeFile.SubmFileStatus = (int)ExchangeFileStatus.Uploaded;
                    lvFiles.SelectedItems[0].SubItems[3].Text = _exchangeFileStatusText[(int)ExchangeFileStatus.Uploaded];
                    RefreshButtons();
                }

                Helpers.RunSqlSocWidSubmitT(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spSubmFilePostSent";
                    cmd.Parameters.AddWithValue("@submFileId", exchangeFile.SubmFileId);
                    cmd.ExecuteNonQuery();
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Файли обміну", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MessageBox.Show("Файл передано", "Файли обміну", MessageBoxButtons.OK, MessageBoxIcon.Information);

            exchangeFile.SubmFileStatus = (int)ExchangeFileStatus.Submitted;
            lvFiles.SelectedItems[0].SubItems[3].Text = _exchangeFileStatusText[(int)ExchangeFileStatus.Submitted];
            RefreshButtons();
        }

        private void btnLoadResponces_Click(object sender, EventArgs e)
        {
            var wtb = new WidTransBuilder();
            using (var wc = new WaitCursor())
            {
                wtb.CheckDeclinedFiles();
                wtb.LoadRespFiles();
                RefreshControls();
            }
        }

        private void ShowFileInFolder(string fileFullName)
        {
            if (!File.Exists(fileFullName))
            {
                MessageBox.Show("Файл не знайдений", "Файли обміну", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var argument = $"/select, \"{fileFullName}\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        private void btnShowSubmFileInFolder_Click(object sender, EventArgs e)
        {
            var fileFullName = Path.Combine(ConfigurationManager.AppSettings["FileExchangeRootDir"], 
                "OutFiles", 
                lvFiles.SelectedItems[0].SubItems[1].Text);
            ShowFileInFolder(fileFullName);
        }

        private void btnShowRespFileInFolder_Click(object sender, EventArgs e)
        {
            var fileFullName = Path.Combine(ConfigurationManager.AppSettings["FileExchangeRootDir"],
                "RespFiles",
                lvFiles.SelectedItems[0].SubItems[2].Text);
            ShowFileInFolder(fileFullName);
        }
    }
}
