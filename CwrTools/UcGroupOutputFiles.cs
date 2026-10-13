using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CwrTools.UcOutputFiles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CwrTools
{
    public partial class UcGroupOutputFiles : UserControl
    {
        public enum FileStatusEnum
        {
            New, Approved, Sent
        }

        public string[] StatusName = new string[3] {"Новий", "До передачі", "Переданий" };

        public class FileInfo
        {
                public int CwrFileId     { get; set; }
                public string Path          { get; set; }
                public string Name          { get; set; }
                public string SenderName    { get; set; }
                public DateTime CreationDate  { get; set; }
                public int Status  { get; set; }
        }

        private List<FileInfo> _fileInfoList;
        private FileInfo _newFileInfo;

        private int _groupId;

        public UcGroupOutputFiles()
        {
            InitializeComponent();
        }

        private void UcOutputFiles_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvFiles.FullRowSelect = true;
            lvFiles.GridLines = true;
            lvFiles.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvFiles.MultiSelect = false;
            lvFiles.View = View.Details;

            lvFiles.Columns.Clear();
            lvFiles.Columns.Add("Код", 100);
            lvFiles.Columns.Add("Початкове розташування файлу", 300);
            lvFiles.Columns.Add("Назва", 200);
            lvFiles.Columns.Add("Відправник", 100);
            lvFiles.Columns.Add("Дата створення", 100);
            lvFiles.Columns.Add("Статус", 100);
        }

        public void LoadData()
        {
            _fileInfoList = new List<FileInfo>();
            _newFileInfo = null;
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                        select t1.CwrFileId, t1.Path, t1.Name, t2.SenderName, t2.CreationDate, t1.Status
                        from CwrFiles t1
	                        join RecHdr t2 on t1.CwrFileId = t2.CwrFileId
                        where Direction = 'OUT'
                            and PartnerGroupId = @groupId
                        order by CreationDate desc
                ";
                cmd.Parameters.AddWithValue("@groupId", _groupId);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var fileInfo = new FileInfo
                        {
                            CwrFileId = r.GetInt32(0),
                            Path = r.GetString(1),
                            Name = r.GetString(2),
                            SenderName = r.GetString(3),
                            CreationDate = r.GetDateTime(4),
                            Status = r.GetInt32(5),
                        };
                        _fileInfoList.Add(fileInfo);

                        if(fileInfo.Status == (int)FileStatusEnum.New || fileInfo.Status == (int)FileStatusEnum.Approved)
                        {
                            _newFileInfo = fileInfo;
                        }
                    }
                }
            });

        }
        
        public void RefreshData(int groupId)
        {
            _groupId = groupId;

            LoadData();

            lvFiles.Items.Clear();
            _fileInfoList.ForEach(x =>
            {
                var item = lvFiles.Items.Add(x.CwrFileId.ToString());
                item.SubItems.Add(x.Path);
                item.SubItems.Add(x.Name);
                item.SubItems.Add(x.SenderName);
                item.SubItems.Add(x.CreationDate.ToString("yyyy-MM-dd"));
                item.SubItems.Add(StatusName[x.Status]);

                item.Tag = x;
            });

            tbNewFileFullName.Text = _newFileInfo == null ? "" : _newFileInfo.Name;

            RefreshControls();
        }

        public void RefreshControls()
        {
            if (lvFiles.SelectedItems.Count > 0)
            {
                btnShowInFolder.Enabled = true;
            }
            else
            {
                btnShowInFolder.Enabled = false;
            }

            if (_newFileInfo == null)
            {
                btnCreateFile.Visible = true;
                btnChangeStatus.Visible = false;

                btnCreateFile.Text = "Створити новий файл";
            }
            else
            {
                btnCreateFile.Visible = _newFileInfo.Status == (int)FileStatusEnum.New;
                btnChangeStatus.Visible = true;

                btnCreateFile.Text = "Оновити новий файл";
                btnChangeStatus.Text = _newFileInfo.Status == (int)FileStatusEnum.New ? "До передачі" : "Позначити як переданий";
            }
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void btnShowInFolder_Click(object sender, EventArgs e)
        {
            if(lvFiles.SelectedItems.Count == 0) return;

            var fileInfo = (FileInfo)lvFiles.SelectedItems[0].Tag;

            var reader = new CwrFileReader();
            var fileFullName = Path.Combine(fileInfo.Path, fileInfo.Name);
            Process.Start("explorer.exe", "/select, " + fileFullName);
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            var reader = new CwrFileReader();
                
            try
            {
                Cursor = Cursors.WaitCursor;

                if(_newFileInfo != null)
                {
                    reader.UnLoadFile(_newFileInfo.CwrFileId);
                }

                Directory.CreateDirectory(CwrConfig.OutputFilesPath);
                var writer = new CwrFileWriter();
                var fileFullName = writer.CreateFile(CwrConfig.OutputFilesPath);

                var fileName = Path.GetFileName(fileFullName);
                int? cwrFileId = null;
                Helpers.RunSqlCwr(cmd =>
                {
                    cmd.CommandText = "select CwrFileId from CwrFiles where Status is null and Direction = 'OUT'";
                    cwrFileId = (int?)cmd.ExecuteScalar();
                });

                if (cwrFileId != null)
                {
                    reader.UnLoadFile((int)cwrFileId);
                }

                cwrFileId = reader.LoadFile(fileFullName, "OUT");

                Cursor = Cursors.Default;

                LoadData();

                var fs = new CwrFileSplitter(fileFullName, 10000);
                fs.SplitFile();

                RefreshData(_groupId);

            }
            catch(Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Створення файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Helpers.RunSqlCwr(cmd =>
                {
                    cmd.CommandText = "update CwrFiles set Status = Status + 1 where CwrFileId = @CwrFileId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CwrFileId", _newFileInfo.CwrFileId);
                    cmd.ExecuteNonQuery();
                });

                if (_newFileInfo.Status == (int)FileStatusEnum.New)
                {
                    Directory.CreateDirectory(CwrConfig.OutputQueuePath);
                    var sourceFileFullName = Path.Combine(CwrConfig.OutputFilesPath, _newFileInfo.Name);
                    var targetFileFullName = Path.Combine(CwrConfig.OutputQueuePath, _newFileInfo.Name);
                    File.Copy(sourceFileFullName, targetFileFullName, true);
                }
                else if (_newFileInfo.Status == (int)FileStatusEnum.Approved)
                {
                    var sourceFileFullName = Path.Combine(CwrConfig.OutputQueuePath, _newFileInfo.Name);
                    File.Delete(sourceFileFullName);
                }

                RefreshData(_groupId);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Створення файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
